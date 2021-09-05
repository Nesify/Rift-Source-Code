// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Fortnite.AthenaCosmeticLocker
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

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
