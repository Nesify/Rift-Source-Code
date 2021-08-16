// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.Profile
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Rift.Backend.Models.Profile
{
  public class Profile
  {
    [JsonProperty("_id")]
    public string _Id { get; set; }

    [JsonProperty("created")]
    public DateTime Created => DateTime.Now;

    [JsonProperty("updated")]
    public DateTime Updated => DateTime.Now;

    [JsonProperty("rvn")]
    public int Rvn { get; set; }

    [JsonProperty("wipeNumber")]
    public int WipeNumber => 1;

    [JsonProperty("accountId")]
    public string Id { get; set; }

    [JsonProperty("profileId")]
    public string ProfileId { get; set; }

    [JsonProperty("version")]
    public string Version => "rift_v2_release_july_2021";

    [JsonProperty("items")]
    public Dictionary<string, object> Items { get; set; }

    [JsonProperty("stats")]
    public ProfileStats Stats { get; set; }
  }
}
