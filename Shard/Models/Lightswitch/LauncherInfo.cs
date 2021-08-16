// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Lightswitch.LauncherInfo
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
