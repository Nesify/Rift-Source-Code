// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.ItemVariant
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Rift.Backend.Models.Profile
{
  public class ItemVariant
  {
    [JsonProperty("channel")]
    public string Channel { get; set; }

    [JsonProperty("active")]
    public string Active { get; set; }

    [JsonProperty("owned")]
    public List<string> Owned { get; set; }

    [JsonIgnore]
    public string Id { get; set; }
  }
}
