// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.ProfileStats
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Profile
{
  public class ProfileStats
  {
    [JsonProperty("attributes")]
    public object Attributes { get; set; }

    [JsonProperty("commandRevision")]
    public int CommandRevision { get; set; } = -1;
  }
}
