// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Enums.LogCategory
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

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
