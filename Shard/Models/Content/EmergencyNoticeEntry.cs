// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.EmergencyNoticeEntry
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rift.Backend.Models.Content
{
  public class EmergencyNoticeEntry : BasePagesEntry
  {
    public EmergencyNoticeEntry(params PagesMessage[] messages)
      : base("emergencynotice")
    {
      this.News = new BattleRoyaleNews(Array.Empty<object>())
      {
        Messages = ((IEnumerable<PagesMessage>) messages).Select<PagesMessage, PagesMessageBase>((Func<PagesMessage, PagesMessageBase>) (x => new PagesMessage(x.Message.Title, x.Message.Body).Message)).ToList<PagesMessageBase>()
      };
    }

    [JsonProperty("news", Order = -7)]
    public BattleRoyaleNews News { get; set; }
  }
}
