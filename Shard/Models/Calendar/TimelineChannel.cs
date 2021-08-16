// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Calendar.TimelineChannel
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
