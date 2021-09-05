// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Services.UpdateService
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Rift.Frontend.Enums;
using Rift.Frontend.Utilities;
using System.Reflection;

namespace Rift.Frontend.Services
{
  public class UpdateService
  {
    public static string LatestVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

    public bool CheckForUpdates()
    {
      if (UpdateService.LatestVersion != Assembly.GetExecutingAssembly().GetName().Version.ToString())
      {
        Logger.Log("Launcher is out of date! Latest version is " + UpdateService.LatestVersion, LogCategory.UpdaterService, LogType.Warning);
        return true;
      }
      Logger.Log("Launcher up-to-date. Latest version is " + UpdateService.LatestVersion, LogCategory.UpdaterService);
      return false;
    }
  }
}
