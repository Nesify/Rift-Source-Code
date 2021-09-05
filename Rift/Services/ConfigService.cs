// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Services.ConfigService
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Rift.Frontend.Enums;
using Rift.Frontend.Models.Config;
using Rift.Frontend.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


#nullable enable
namespace Rift.Frontend.Services
{
  public class ConfigService
  {
    public static bool EnableFTS = true;

    public 
    #nullable disable
    Configuration Configuration { get; private set; }

    public bool RequireFirstTimeSetup { get; private set; }

    public async Task LoadConfiguration()
    {
      Logger.Log("Loading configuration", LogCategory.ConfigurationService);
      string path = Path.Combine(Strings.CONFIG_PATH, "rift.conf");
      if (!File.Exists(path))
      {
        this.RequireFirstTimeSetup = true;
        Logger.Log("Configuration file doesn't exist! RequireFirstTimeSetup = true", LogCategory.ConfigurationService, LogType.Warning);
        this.Configuration = new Configuration();
      }
      else
      {
        this.Configuration = JsonSerializer.Deserialize<Configuration>(await File.ReadAllTextAsync(path));
        if (await this.ValidateConfiguration() <= 0)
          return;
        await this.SaveConfiguration();
      }
    }

    public async Task SaveConfiguration()
    {
      int num = await this.ValidateConfiguration();
      Logger.Log("Saving configuration", LogCategory.ConfigurationService);
      string contents = JsonSerializer.Serialize<Configuration>(this.Configuration);
      await File.WriteAllTextAsync(Path.Combine(Strings.CONFIG_PATH, "rift.conf"), contents);
    }

    public async Task<int> ValidateConfiguration()
    {
      int num = 0;
      Logger.Log("ValidateConfiguration: Validating configuration", LogCategory.ConfigurationService);
      if (string.IsNullOrWhiteSpace(this.Configuration.DisplayName))
      {
        ++num;
        Logger.Log("ValidateConfiguration: DisplayName is null or empty! Reverting to \"Rift\"", LogCategory.ConfigurationService, LogType.Warning);
        this.Configuration.DisplayName = "Rift";
      }
      if (this.Configuration.LaunchArgs == null)
      {
        ++num;
        Logger.Log("ValidateConfiguration: LaunchArgs is null or empty! Reverting to \"\"", LogCategory.ConfigurationService, LogType.Warning);
        this.Configuration.LaunchArgs = string.Empty;
      }
      if (this.Configuration.Installations == null)
      {
        ++num;
        Logger.Log("ValidateConfiguration: Installations is null!", LogCategory.ConfigurationService, LogType.Warning);
        this.Configuration.Installations = new List<Installation>();
      }
      for (int index = 0; index < this.Configuration.Installations.Count; ++index)
      {
        Installation installation = this.Configuration.Installations[index];
        if (!File.Exists(installation.Path + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe"))
        {
          ++num;
          Logger.Log("ValidateConfiguration: Installation doesn't exist anymore!", LogCategory.ConfigurationService, LogType.Warning);
          this.Configuration.Installations.RemoveAt(index);
          --index;
        }
        else if (this.Configuration.Installations.FindAll((Predicate<Installation>) (x => x.Path == installation.Path)).Count > 1 || this.Configuration.Installations.FindAll((Predicate<Installation>) (x => x.Name == installation.Name)).Count > 1)
        {
          ++num;
          Logger.Log("ValidateConfiguration: Duplicate installation!", LogCategory.ConfigurationService, LogType.Warning);
          this.Configuration.Installations.RemoveAt(index);
          --index;
        }
        else if (installation.Name.Length > 25)
        {
          ++num;
          Logger.Log("ValidateConfiguration: Illegal installation name!", LogCategory.ConfigurationService, LogType.Warning);
          installation.Name = installation.Name.Substring(0, 25 - 0);
        }
      }
      Logger.Log(string.Format("ValidateConfiguration: Done, fixed {0} issue(s)", (object) num), LogCategory.ConfigurationService);
      return num;
    }
  }
}
