// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Calendar.ChannelEvent
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;

namespace Rift.Backend.Models.Calendar
{
  public class ChannelEvent
  {
    public ChannelEvent(string eventType) => this.EventType = eventType;

    [JsonProperty("eventType")]
    public string EventType { get; set; }

    [JsonProperty("activeUntil")]
    public DateTime ActiveUntil => DateTime.MaxValue;

    [JsonProperty("activeSince")]
    public DateTime ActiveSince => DateTime.UtcNow;
  }
}
