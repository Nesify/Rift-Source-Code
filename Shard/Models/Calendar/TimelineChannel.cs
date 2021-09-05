// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Calendar.TimelineChannel
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rift.Backend.Models.Calendar
{
  public class TimelineChannel
  {
    [JsonProperty("states")]
    public List<ChannelState> States { get; set; }

    [JsonProperty("cacheExpire")]
    public DateTime CacheExpire => DateTime.UtcNow.AddMinutes(15.0);

    public TimelineChannel(params ChannelState[] states) => this.States = ((IEnumerable<ChannelState>) states).ToList<ChannelState>();
  }
}
