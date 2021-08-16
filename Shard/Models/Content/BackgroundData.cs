// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.BackgroundData
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
