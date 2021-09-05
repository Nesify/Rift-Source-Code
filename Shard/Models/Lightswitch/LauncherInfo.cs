// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Lightswitch.LauncherInfo
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Lightswitch
{
  public class LauncherInfo
  {
    [JsonProperty("appName")]
    public string AppName => "Fortnite";

    [JsonProperty("catalogItemId")]
    public string CatalogItemId => "4fe75bbc5a674f4f9b356b5c90567da5";

    [JsonProperty("namespace")]
    public string Namespace => "fn";
  }
}
