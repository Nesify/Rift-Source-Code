// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Utilities.Strings
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using System;
using System.Reflection;

namespace Rift.Frontend.Utilities
{
  public static class Strings
  {
    public static readonly string TRIMMED_VERSION_STRING = string.Format("{0}.{1}.{2}", (object) Assembly.GetExecutingAssembly().GetName().Version.Major, (object) Assembly.GetExecutingAssembly().GetName().Version.Minor, (object) Assembly.GetExecutingAssembly().GetName().Version.Build);
    private static readonly bool _isBoosters = Assembly.GetExecutingAssembly().GetName().Version.Revision == (int) byte.MaxValue;
    private static readonly string _versionString = Strings._isBoosters ? Strings.TRIMMED_VERSION_STRING : Assembly.GetExecutingAssembly().GetName().Version.ToString();
    public static readonly string CONFIG_PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Rift";
    public static readonly string MODS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Rift/Mods";
    public static readonly string LOG_PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Rift/Rift.log";
    public static readonly string VERSION_STRING = "rift+" + Strings._boostersOrProd + "-" + Strings._versionString;

    private static string _boostersOrProd => !Strings._isBoosters ? "prod" : "booster";
  }
}
