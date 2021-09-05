// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Calendar.ChannelEvent
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

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
