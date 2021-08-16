// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Fortnite.AthenaCosmeticLocker
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Fortnite
{
  public class AthenaCosmeticLocker
  {
    [JsonProperty("locker_slots_data")]
    public AthenaLockerSlotsData LockerSlotsData { get; set; }

    [JsonProperty("use_count")]
    public int UseCount => 0;

    [JsonProperty("banner_icon_template")]
    public string BannerIcon { get; set; }

    [JsonProperty("banner_color_template")]
    public string BannerColor { get; set; }

    [JsonProperty("locker_name")]
    public string LockerName { get; set; }

    [JsonProperty("item_seen")]
    public bool ItemSeen => false;

    [JsonProperty("favorite")]
    public bool Favorite => false;
  }
}
