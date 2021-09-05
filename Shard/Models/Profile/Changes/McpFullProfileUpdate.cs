// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.Changes.McpFullProfileUpdate
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Profile.Changes
{
  public class McpFullProfileUpdate : McpChange
  {
    public McpFullProfileUpdate(Rift.Backend.Models.Profile.Profile profile)
      : base("fullProfileUpdate")
    {
      this.Profile = profile;
    }

    [JsonProperty("profile")]
    public Rift.Backend.Models.Profile.Profile Profile { get; set; }
  }
}
