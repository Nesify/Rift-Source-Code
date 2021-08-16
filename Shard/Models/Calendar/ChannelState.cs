// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Calendar.ChannelState
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Rift.Backend.Models.Calendar
{
  public class ChannelState
  {
    [JsonProperty("validFrom")]
    public DateTime ValidFrom { get; set; } = DateTime.UtcNow;

    [JsonProperty("activeEvents")]
    public List<ChannelEvent> ActiveEvents { get; set; }

    [JsonProperty("state")]
    public object State { get; set; }
  }
}
