// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.SubgameSelectEntry
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Content
{
  public class SubgameSelectEntry : BasePagesEntry
  {
    [JsonProperty("saveTheWorldUnowned", Order = -7)]
    public PagesMessage SaveTheWorldUnowned => this.SaveTheWorld;

    [JsonProperty("battleRoyale", Order = -7)]
    public PagesMessage BattleRoyale { get; set; }

    [JsonProperty("creative", Order = -7)]
    public PagesMessage Creative { get; set; }

    [JsonProperty("saveTheWorld", Order = -7)]
    public PagesMessage SaveTheWorld { get; set; }

    public SubgameSelectEntry()
      : base("subgameselectdata")
    {
    }
  }
}
