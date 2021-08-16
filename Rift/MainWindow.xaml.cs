// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.MainWindow
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.MobileBlazorBindings;
using Microsoft.MobileBlazorBindings.Hosting;
using Microsoft.MobileBlazorBindings.WPF;
using Microsoft.Web.WebView2.Core;
using Rift.Backend.Models.Exceptions;
using Rift.Frontend.Enums;
using Rift.Frontend.Services;
using Rift.Frontend.Utilities;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;


#nullable enable
namespace Rift.Frontend
{
  public partial class MainWindow : Window, IComponentConnector
  {
    public static bool IgnoreWebExceptions = true;
    private bool _halted;
    internal 
    #nullable disable
    BlazorWebView MyBlazorWebView;
    private bool _contentLoaded;

    public MainWindow()
    {
      MainWindow.Instance = this;
      this.InitializeComponent();
      this.InitializeAsync();
    }

    public static MainWindow Instance { get; private set; }

    private async Task InitializeAsync()
    {
      MainWindow mainWindow = this;
      AppDomain.CurrentDomain.FirstChanceException += new EventHandler<FirstChanceExceptionEventArgs>(mainWindow.CurrentDomainOnFirstChanceException);
      Directory.CreateDirectory(Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rift"));
      Logger.Start();
      string str = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? "yes" : "no";
      Logger.Log("OS: " + Environment.OSVersion.VersionString);
      Logger.Log("Launcher: " + Strings.VERSION_STRING);
      Logger.Log("Running as admin: " + str);
      Logger.Log("");
      mainWindow.MyBlazorWebView.ComponentType = typeof (MainPage);
      Logger.Log("Building host");
      IHost host = BlazorWebHost.CreateDefaultBuilder().ConfigureServices((Action<HostBuilderContext, IServiceCollection>) ((_, services) =>
      {
        services.AddBlazorHybrid();
        services.AddScoped<ConfigService>();
        services.AddScoped<UpdateService>();
        services.AddScoped<Hammer>();
        services.AddScoped<RichPresenceService>();
        services.AddScoped<LauncherService>();
      })).UseWebRoot("wwwroot").UseStaticFiles().Build();
      mainWindow.MyBlazorWebView.Host = host;
      // ISSUE: reference to a compiler-generated method
      mainWindow.Loaded += new RoutedEventHandler(mainWindow.\u003CInitializeAsync\u003Eb__7_1);
      await Hammer.Patch();
    }

    private void CurrentDomainOnFirstChanceException(
    #nullable enable
    object? sender, 
    #nullable disable
    FirstChanceExceptionEventArgs e)
    {
      Exception exception = e.Exception;
      if (exception.StackTrace != null && exception.StackTrace.Contains("ToastNotification"))
        return;
      switch (exception)
      {
        case WebException webException:
          if (MainWindow.IgnoreWebExceptions)
            break;
          switch (webException.Status)
          {
            case WebExceptionStatus.NameResolutionFailure:
              return;
            case WebExceptionStatus.ProtocolError:
              return;
            default:
              int num1 = (int) MessageBox.Show("An error occurred trying to connect to the server. If you're using Fiddler, please restart Rift.", "Please restart Rift", MessageBoxButton.OK, MessageBoxImage.Asterisk);
              Environment.Exit(0);
              return;
          }
        case EdgeNotFoundException _:
          if (MessageBox.Show("You need to install Microsoft Edge WebView 2 to use the Rift Launcher. Do you want to install it now?", "Rift", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            WindowsUtilities.OpenURL("https://msedge.sf.dl.delivery.mp.microsoft.com/filestreamingservice/files/2a723731-d64d-4119-8214-9781c986c21b/MicrosoftEdgeWebView2RuntimeInstallerX64.exe");
          Environment.Exit(0);
          break;
        case FileNotFoundException _:
        case DllNotFoundException _:
          int num2 = (int) MessageBox.Show("Important files seem to have been deleted from Rift. Please redownload the launcher and check if your antivirus might be deleting files.", "File missing", MessageBoxButton.OK, MessageBoxImage.Asterisk);
          Environment.Exit(0);
          break;
        case BaseException _:
          break;
        case COMException _:
          break;
        case Win32Exception _:
          break;
        default:
          if (this._halted || exception.StackTrace != null && !exception.StackTrace.Contains("Rift.Frontend"))
            break;
          this._halted = true;
          Logger.Log("An unhandled exception occurred.", level: LogType.Exception);
          Logger.Log(exception.GetType().Name + ": " + exception.Message, level: LogType.Exception);
          Logger.Log(exception.StackTrace ?? "", level: LogType.Exception);
          int num3 = (int) MessageBox.Show("Rift has encountered a fatal error and needs to restart, sorry about that. Please send a crash log in the bug reports channel in discord.gg/RiftFN", "Rift needs to restart", MessageBoxButton.OK, MessageBoxImage.Error);
          Process.Start("notepad.exe", Strings.LOG_PATH);
          Environment.Exit(0);
          break;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.6.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Rift;V2.1.0.3;component/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.6.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this.MyBlazorWebView = (BlazorWebView) target;
      else
        this._contentLoaded = true;
    }
  }
}
