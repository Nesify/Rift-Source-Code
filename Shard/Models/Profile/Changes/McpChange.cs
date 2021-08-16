// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.Changes.McpChange
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Profile.Changes
{
  public class McpChange
  {
    [JsonProperty("changeType", Order = -2)]
    public string ChangeType { get; set; }

    public McpChange(string changeType) => this.ChangeType = changeType;
  }
}
