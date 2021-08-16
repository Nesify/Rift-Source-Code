// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Enums.LogCategory
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using System.ComponentModel;

namespace Rift.Frontend.Enums
{
  public enum LogCategory
  {
    [Description("Debug.gray")] None,
    [Description("Configuration.#84d1fa")] ConfigurationService,
    [Description("Hammer.mediumspringgreen")] Patcher,
    [Description("Launcher.#fa84cf")] LauncherService,
    [Description("Discord.#848efa")] RichPresenceService,
    [Description("Updater.#faec84")] UpdaterService,
    [Description("Iron.#a19d94")] Injector,
    [Description("Mods.#afed9d")] ModService,
  }
}
