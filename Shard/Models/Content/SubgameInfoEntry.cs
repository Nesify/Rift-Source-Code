// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.SubgameInfoEntry
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Content
{
  public class SubgameInfoEntry : BasePagesEntry
  {
    [JsonProperty("battleroyale")]
    public SubgameInfo BattleRoyale { get; set; }

    [JsonProperty("savetheworld")]
    public SubgameInfo SaveTheWorld { get; set; }

    [JsonProperty("creative")]
    public SubgameInfo Creative { get; set; }

    public SubgameInfoEntry()
      : base("SubgameInfo")
    {
    }
  }
}
