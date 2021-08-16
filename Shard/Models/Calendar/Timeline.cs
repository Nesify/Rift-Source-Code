// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Calendar.Timeline
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Rift.Backend.Models.Calendar
{
  public class Timeline
  {
    [JsonProperty("channels")]
    public Dictionary<string, TimelineChannel> Channels { get; set; }

    [JsonProperty("currentTime")]
    public DateTime CurrentTime => DateTime.UtcNow;

    [JsonProperty("cacheIntervalMins")]
    public double CacheIntervalMinutes => 15.0;
  }
}
