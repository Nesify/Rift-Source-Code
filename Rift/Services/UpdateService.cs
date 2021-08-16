// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Services.UpdateService
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

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
