// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.ItemAttributes
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Rift.Backend.Models.Profile
{
  public class ItemAttributes
  {
    [JsonProperty("max_level_bonus")]
    public int MaxLevelBonus => 1;

    [JsonProperty("level")]
    public int Level => 1;

    [JsonProperty("item_seen")]
    public bool ItemSeen => true;

    [JsonProperty("xp")]
    public int Xp => 0;

    [JsonProperty("variants", NullValueHandling = NullValueHandling.Ignore)]
    public List<ItemVariant> Variants { get; set; }

    [JsonProperty("favorite")]
    public bool Favorite => false;
  }
}
