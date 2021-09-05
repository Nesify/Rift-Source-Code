// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Calendar.States.ClientEventsState
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Rift.Backend.Models.Calendar.States
{
  public class ClientEventsState
  {
    public ClientEventsState(int seasonNumber)
    {
      this.SeasonNumber = seasonNumber;
      this.SeasonTemplateId = string.Format("AthenaSeason:athenaseason{0}", (object) seasonNumber);
    }

    [JsonProperty("activeStorefronts")]
    public string[] ActiveStorefronts => Array.Empty<string>();

    [JsonProperty("eventNamedWeights")]
    public Dictionary<string, double> EventNamedWeights => new Dictionary<string, double>();

    [JsonProperty("seasonNumber")]
    public int SeasonNumber { get; set; }

    [JsonProperty("seasonTemplateId")]
    public string SeasonTemplateId { get; set; }

    [JsonProperty("matchXpBonusPoints")]
    public float MatchXpBonusPoints => 0.0f;

    [JsonProperty("eventPunchCardTemplateId")]
    public string EventPunchCardTemplateId => "";

    [JsonProperty("seasonBegin")]
    public DateTime SeasonBegin => DateTime.UtcNow.AddMonths(-1);

    [JsonProperty("seasonEnd")]
    public DateTime SeasonEnd => DateTime.MaxValue;

    [JsonProperty("seasonDisplayedEnd")]
    public DateTime SeasonDisplayedEnd => DateTime.MaxValue;

    [JsonProperty("weeklyStoreEnd")]
    public DateTime WeeklyStoreEnd => DateTime.MaxValue;

    [JsonProperty("dailyStoreEnd")]
    public DateTime DailyStoreEnd => DateTime.MaxValue;

    [JsonProperty("stwDailyStoreEnd")]
    public DateTime StwDailyStoreEnd => DateTime.MaxValue;

    [JsonProperty("stwEventStoreEnd")]
    public DateTime StwEventStoreEnd => DateTime.MaxValue;

    [JsonProperty("stwWeeklyStoreEnd")]
    public DateTime StwWeeklyStoreEnd => DateTime.MaxValue;

    [JsonProperty("sectionStoreEnds")]
    public Dictionary<string, DateTime> SectionStoreEnds => new Dictionary<string, DateTime>();
  }
}
