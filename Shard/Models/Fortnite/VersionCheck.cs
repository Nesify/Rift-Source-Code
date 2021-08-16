// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Fortnite.VersionCheck
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Fortnite
{
  public class VersionCheck
  {
    [JsonProperty("type")]
    public string Type { get; set; }

    public VersionCheck(string type) => this.Type = type;
  }
}
