// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.BattleRoyaleNews
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rift.Backend.Models.Content
{
  public class BattleRoyaleNews
  {
    public BattleRoyaleNews(params object[] motds)
    {
      this.Messages = ((IEnumerable<object>) motds).Select<object, PagesMessageBase>((Func<object, PagesMessageBase>) (x =>
      {
        BattleRoyaleNewsMOTD battleRoyaleNewsMotd = (BattleRoyaleNewsMOTD) x;
        return new PagesMessage(battleRoyaleNewsMotd.Title, battleRoyaleNewsMotd.Body, battleRoyaleNewsMotd.TileImage).Message;
      })).Where<PagesMessageBase>((Func<PagesMessageBase, bool>) (x => x != null)).ToList<PagesMessageBase>();
      this.MOTDS = ((IEnumerable<object>) motds).ToList<object>();
    }

    [JsonProperty("messages")]
    public List<PagesMessageBase> Messages { get; set; }

    [JsonProperty("motds")]
    public List<object> MOTDS { get; set; }
  }
}
