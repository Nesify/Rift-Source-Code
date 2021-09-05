// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Services.LauncherService
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Microsoft.JSInterop;
using Microsoft.Toolkit.Uwp.Notifications;
using Newtonsoft.Json;
using Rift.Backend.Controllers;
using Rift.Frontend.Enums;
using Rift.Frontend.Models;
using Rift.Frontend.Models.Config;
using Rift.Frontend.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;


#nullable enable
namespace Rift.Frontend.Services
{
  public class LauncherService
  {
    public static bool UseNitestatsForFLToken = true;
    public static bool ShowToastNotification = true;
    private readonly 
    #nullable disable
    ConfigService _configService;
    private readonly IJSRuntime _jsRuntime;
    private readonly RichPresenceService _richPresenceService;
    private Process _fortniteProcess;
    private Process _fnLauncherProcess;
    private Process _fnAntiCheatProcess;

    public LauncherService(
      RichPresenceService richPresenceService,
      ConfigService configService,
      IJSRuntime jsRuntime)
    {
      this._richPresenceService = richPresenceService;
      this._configService = configService;
      this._jsRuntime = jsRuntime;
      MainWindow.Instance.Closing += (CancelEventHandler) ((sender, args) =>
      {
        this._fortniteProcess?.Kill();
        this._fnLauncherProcess?.Kill();
        this._fnAntiCheatProcess?.Kill();
      });
    }

    private static extern void Glue(IntPtr handle, string path);

    public async Task StartGame(Installation installation)
    {
      LauncherService launcherService = this;
      Logger.Log("Starting " + installation.Id, LogCategory.LauncherService);
      string gamePath;
      string tempPath;
      string flToken;
      if (launcherService._fortniteProcess != null)
      {
        Logger.Log("Fortnite is already running!", LogCategory.LauncherService, LogType.Warning);
        if (MessageBox.Show("Fortnite is already running! Do you want to stop playing to launch this version?", "Game already running", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
        {
          gamePath = (string) null;
          tempPath = (string) null;
          flToken = (string) null;
          return;
        }
        Logger.Log("Killing old session to start new session", LogCategory.LauncherService);
        launcherService._fortniteProcess?.Kill();
        launcherService._fortniteProcess = (Process) null;
      }
      McpController.OnRiftRequested += new Action(launcherService.OnRiftRequested);
      launcherService._richPresenceService.SetPlayingFortnite(installation);
      if (LauncherService.ShowToastNotification)
        new ToastContentBuilder().AddText("Starting " + installation.Name).AddText("Please wait, this might take a while...").Show();
      int num1 = await launcherService._configService.ValidateConfiguration();
      Logger.Log("DisplayName: " + launcherService._configService.Configuration.DisplayName, LogCategory.LauncherService);
      gamePath = installation.Path + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe";
      tempPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rift");
      if (!System.IO.File.Exists(gamePath))
      {
        Logger.Log("The game path didn't have a Fortnite version installed!", LogCategory.LauncherService, LogType.Error);
        int num2 = (int) MessageBox.Show("The path you provided doesn't have Fortnite installed! Make sure the path points to the folder that contains the FortniteGame and Engine folders.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        gamePath = (string) null;
        tempPath = (string) null;
        flToken = (string) null;
      }
      else
      {
        Logger.Log("Path: " + installation.Path + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe", LogCategory.LauncherService);
        if (App.Args.Length <= 1 || !(App.Args[0].ToLower() == "-launch"))
          MainWindow.Instance.WindowState = WindowState.Minimized;
        flToken = "7a848a93a74ba68876c36C1c";
        if (LauncherService.UseNitestatsForFLToken)
        {
          try
          {
            flToken = JsonConvert.DeserializeObject<Nitestats.FlToken>(await new WebClient().DownloadStringTaskAsync("https://api.nitestats.com/v1/epic/builds/fltoken"))?.Token;
            Logger.Log("FLToken: " + flToken, LogCategory.LauncherService);
          }
          catch
          {
            Logger.Log("Failed to retrieve FL Token! Using fallback FL Token.", LogCategory.LauncherService, LogType.Error);
          }
        }
        Logger.Log("Unpacking fake anti-cheat", LogCategory.LauncherService);
        if (!System.IO.File.Exists(Path.Join(tempPath, "FortniteLauncher.exe")))
          await WindowsUtilities.UnpackResource("FortniteLauncher.exe");
        if (!System.IO.File.Exists(Path.Join(tempPath, "FortniteClient-Win64-Shipping_BE.exe")))
          await WindowsUtilities.UnpackResource("FortniteClient-Win64-Shipping_BE.exe");
        Logger.Log("Filtering launch arguments", LogCategory.LauncherService);
        List<string> baseArgs = new List<string>()
        {
          "-AUTH_LOGIN=" + launcherService._configService.Configuration.DisplayName + "@riftfn.xyz",
          "-AUTH_PASSWORD=unused",
          "-AUTH_TYPE=epic",
          "-epicapp=Fortnite",
          "-epicportal",
          "-fltoken=" + flToken,
          "-fromfl=none",
          "-noeac",
          "-nobe",
          "-skippatchcheck"
        };
        string str1 = launcherService._configService.Configuration.LaunchArgs.Split(" ").FilterLaunchArguments(baseArgs);
        string str2 = Assembly.GetExecutingAssembly().Location.Replace("Rift.dll", "");
        launcherService._fortniteProcess = new Process()
        {
          StartInfo = new ProcessStartInfo()
          {
            Arguments = str1,
            FileName = gamePath
          },
          EnableRaisingEvents = true
        };
        Logger.Log("Starting FortniteClient-Win64-Shipping.exe", LogCategory.LauncherService);
        launcherService._fortniteProcess.Exited += new EventHandler(launcherService.OnFortniteProcessExited);
        launcherService._fortniteProcess.Start();
        launcherService._fnLauncherProcess = Process.Start(new ProcessStartInfo()
        {
          Arguments = str1,
          CreateNoWindow = true,
          FileName = Path.Join(tempPath, "FortniteLauncher.exe")
        });
        launcherService._fnAntiCheatProcess = Process.Start(new ProcessStartInfo()
        {
          Arguments = str1,
          CreateNoWindow = true,
          FileName = Path.Join(tempPath, "FortniteClient-Win64-Shipping_BE.exe")
        });
        Logger.Log("Gluing Sun", LogCategory.Injector);
        LauncherService.Glue(launcherService._fortniteProcess.Handle, str2 + "Sun.dll");
        gamePath = (string) null;
        tempPath = (string) null;
        flToken = (string) null;
      }
    }

    public async Task StartGameWithLuna(Installation installation)
    {
      LauncherService launcherService = this;
      Logger.Log("Starting " + installation.Id, LogCategory.LauncherService);
      string gamePath;
      string tempPath;
      string flToken;
      if (launcherService._fortniteProcess != null)
      {
        Logger.Log("Fortnite is already running!", LogCategory.LauncherService, LogType.Warning);
        if (MessageBox.Show("Fortnite is already running! Do you want to stop playing to launch this version?", "Game already running", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
        {
          gamePath = (string) null;
          tempPath = (string) null;
          flToken = (string) null;
          return;
        }
        Logger.Log("Killing old session to start new session", LogCategory.LauncherService);
        launcherService._fortniteProcess?.Kill();
        launcherService._fortniteProcess = (Process) null;
      }
      launcherService._richPresenceService.SetPlayingFortnite(installation);
      if (LauncherService.ShowToastNotification)
        new ToastContentBuilder().AddText("Sending you into Rift Multiplayer!").AddText("Please note that you will need to log in with a Luna account. For instructions on how to make one, join our Discord Server!").Show();
      int num1 = await launcherService._configService.ValidateConfiguration();
      Logger.Log("DisplayName: " + launcherService._configService.Configuration.DisplayName, LogCategory.LauncherService);
      gamePath = installation.Path + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe";
      tempPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rift");
      if (!System.IO.File.Exists(gamePath))
      {
        Logger.Log("The game path didn't have a Fortnite version installed!", LogCategory.LauncherService, LogType.Error);
        int num2 = (int) MessageBox.Show("The path you provided doesn't have Fortnite installed! Make sure the path points to the folder that contains the FortniteGame and Engine folders.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        gamePath = (string) null;
        tempPath = (string) null;
        flToken = (string) null;
      }
      else
      {
        Logger.Log("Path: " + installation.Path + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe", LogCategory.LauncherService);
        if (App.Args.Length <= 1 || !(App.Args[0].ToLower() == "-launch"))
          MainWindow.Instance.WindowState = WindowState.Minimized;
        flToken = "7a848a93a74ba68876c36C1c";
        if (LauncherService.UseNitestatsForFLToken)
        {
          try
          {
            flToken = JsonConvert.DeserializeObject<Nitestats.FlToken>(await new WebClient().DownloadStringTaskAsync("https://api.nitestats.com/v1/epic/builds/fltoken"))?.Token;
            Logger.Log("FLToken: " + flToken, LogCategory.LauncherService);
          }
          catch
          {
            Logger.Log("Failed to retrieve FL Token! Using fallback FL Token.", LogCategory.LauncherService, LogType.Error);
          }
        }
        Logger.Log("Unpacking fake anti-cheat", LogCategory.LauncherService);
        if (!System.IO.File.Exists(Path.Join(tempPath, "FortniteLauncher.exe")))
          await WindowsUtilities.UnpackResource("FortniteLauncher.exe");
        if (!System.IO.File.Exists(Path.Join(tempPath, "FortniteClient-Win64-Shipping_BE.exe")))
          await WindowsUtilities.UnpackResource("FortniteClient-Win64-Shipping_BE.exe");
        Logger.Log("Filtering launch arguments", LogCategory.LauncherService);
        List<string> baseArgs = new List<string>()
        {
          "-epicapp=Fortnite",
          "-epicportal",
          "-fltoken=" + flToken,
          "-fromfl=none",
          "-noeac",
          "-nobe",
          "-skippatchcheck"
        };
        string str1 = launcherService._configService.Configuration.LaunchArgs.Split(" ").FilterLaunchArguments(baseArgs);
        string str2 = Assembly.GetExecutingAssembly().Location.Replace("Rift.dll", "");
        launcherService._fortniteProcess = new Process()
        {
          StartInfo = new ProcessStartInfo()
          {
            Arguments = str1,
            FileName = gamePath
          },
          EnableRaisingEvents = true
        };
        Logger.Log("Starting FortniteClient-Win64-Shipping.exe", LogCategory.LauncherService);
        launcherService._fortniteProcess.Exited += new EventHandler(launcherService.OnFortniteProcessExited);
        launcherService._fortniteProcess.Start();
        launcherService._fnLauncherProcess = Process.Start(new ProcessStartInfo()
        {
          Arguments = str1,
          CreateNoWindow = true,
          FileName = Path.Join(tempPath, "FortniteLauncher.exe")
        });
        launcherService._fnAntiCheatProcess = Process.Start(new ProcessStartInfo()
        {
          Arguments = str1,
          CreateNoWindow = true,
          FileName = Path.Join(tempPath, "FortniteClient-Win64-Shipping_BE.exe")
        });
        Logger.Log("Gluing Gluna", LogCategory.Injector);
        LauncherService.Glue(launcherService._fortniteProcess.Handle, str2 + "Gluna.dll");
        gamePath = (string) null;
        tempPath = (string) null;
        flToken = (string) null;
      }
    }

    private void OnFortniteProcessExited(object sender, EventArgs e)
    {
      Process fortniteProcess = this._fortniteProcess;
      if (fortniteProcess != null && fortniteProcess.HasExited)
      {
        Logger.Log(string.Format("Game exited with code {0}", (object) this._fortniteProcess.ExitCode), LogCategory.LauncherService);
        this._fortniteProcess = (Process) null;
      }
      this._fnLauncherProcess?.Kill();
      this._fnAntiCheatProcess?.Kill();
      this._richPresenceService.SetPlayingFortnite((Installation) null);
    }

    private void OnRiftRequested()
    {
      Logger.Log("Gluing Moon", LogCategory.Injector);
      LauncherService.Glue(this._fortniteProcess.Handle, Assembly.GetExecutingAssembly().Location.Replace("Rift.dll", "") + "Moon.dll");
    }

    public async Task<bool> RegisterGame(string name, string path)
    {
      if (string.IsNullOrWhiteSpace(name))
      {
        int num = (int) MessageBox.Show("Name cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return false;
      }
      if (!System.IO.File.Exists(Path.Join(path, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe")))
      {
        int num = (int) MessageBox.Show("The path you provided doesn't have Fortnite installed! Make sure the path points to the folder that contains the FortniteGame and Engine folders.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return false;
      }
      if (!this._configService.RequireFirstTimeSetup)
      {
        string str = await this._jsRuntime.InvokeAsync<string>("rift.modalManager.hideModal", (object) "new-game");
      }
      this._configService.Configuration.Installations.Add(new Installation()
      {
        Path = path,
        Name = name
      });
      await this._configService.SaveConfiguration();
      return true;
    }
  }
}
