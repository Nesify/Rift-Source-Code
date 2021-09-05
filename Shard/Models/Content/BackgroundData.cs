// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.BackgroundData
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Content
{
  public class BackgroundData
  {
    public BackgroundData(string stage = null, string key = null)
    {
      this.Stage = stage;
      this.Key = key;
    }

    [JsonProperty("stage", NullValueHandling = NullValueHandling.Ignore)]
    public string Stage { get; set; }

    [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
    public string Key { get; set; }

    [JsonProperty("_type")]
    public string Type => "DynamicBackground";
  }
}
