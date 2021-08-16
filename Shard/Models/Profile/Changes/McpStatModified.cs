// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.Changes.McpStatModified
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Profile.Changes
{
  public class McpStatModified : McpChange
  {
    [JsonProperty("name")]
    public string Stat { get; set; }

    [JsonProperty("value")]
    public object Value { get; set; }

    public McpStatModified(string stat, object value)
      : base("statModified")
    {
      this.Stat = stat;
      this.Value = value;
    }
  }
}
