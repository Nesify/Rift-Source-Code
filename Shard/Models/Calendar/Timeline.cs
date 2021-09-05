// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Calendar.Timeline
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

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
