// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.Pages
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Content
{
  public class Pages : BasePagesEntry
  {
    [JsonProperty("battleroyalenews", NullValueHandling = NullValueHandling.Ignore)]
    public BattleRoyaleNewsEntry BattleRoyaleNews { get; set; }

    [JsonProperty("battleroyalenewsv2", NullValueHandling = NullValueHandling.Ignore)]
    public BattleRoyaleNewsEntry BattleRoyaleNewsV2 => this.BattleRoyaleNews;

    [JsonProperty("emergencynotice", NullValueHandling = NullValueHandling.Ignore)]
    public EmergencyNoticeEntry EmergencyNotice { get; set; }

    [JsonProperty("emergencynoticev2", NullValueHandling = NullValueHandling.Ignore)]
    public EmergencyNoticeEntry EmergencyNoticeV2 => this.EmergencyNotice;

    [JsonProperty("subgameinfo", NullValueHandling = NullValueHandling.Ignore)]
    public SubgameInfoEntry SubgameInfo { get; set; }

    [JsonProperty("subgameselectdata", NullValueHandling = NullValueHandling.Ignore)]
    public SubgameSelectEntry SubgameSelect { get; set; }

    [JsonProperty("dynamicbackgrounds", NullValueHandling = NullValueHandling.Ignore)]
    public DynamicBackground DynamicBackgrounds { get; set; }

    public Pages()
      : base("Fortnite Game")
    {
    }
  }
}
