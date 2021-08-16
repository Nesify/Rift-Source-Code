// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.ItemVariant
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Rift.Backend.Models.Profile
{
  public class ItemVariant
  {
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("active")]
    public string Active { get; set; }

    [JsonProperty("owned")]
    public List<string> Owned { get; set; }

    [JsonIgnore]
    public string Id { get; set; }
  }
}
