// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Controllers.CalendarController
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Microsoft.AspNetCore.Mvc;
using Rift.Backend.Models.Calendar;
using Rift.Backend.Models.Calendar.States;
using System;
using System.Collections.Generic;

namespace Rift.Backend.Controllers
{
  [Route("fortnite/api/[controller]/v1/timeline")]
  [ApiController]
  public class CalendarController : ControllerBase
  {
    public ActionResult<Timeline> GetTimeline()
    {
      int seasonNumber = this.Request.GetSeasonNumber();
      Decimal buildVersion = this.Request.GetBuildVersion();
      string str = seasonNumber == 2 ? "LobbyWinterDecor" : string.Format("LobbySeason{0}", (object) seasonNumber);
      Timeline timeline1 = new Timeline();
      Timeline timeline2 = timeline1;
      Dictionary<string, TimelineChannel> dictionary1 = new Dictionary<string, TimelineChannel>();
      dictionary1["standalone-store"] = new TimelineChannel(new ChannelState[1]
      {
        new ChannelState()
        {
          ActiveEvents = new List<ChannelEvent>(),
          State = (object) new StandaloneStoreState()
        }
      });
      dictionary1["client-events"] = new TimelineChannel(new ChannelState[1]
      {
        new ChannelState()
        {
          ActiveEvents = new List<ChannelEvent>()
          {
            new ChannelEvent("EventFlag." + str)
          },
          State = (object) new ClientEventsState(seasonNumber)
        }
      });
      Dictionary<string, TimelineChannel> dictionary2 = dictionary1;
      timeline2.Channels = dictionary2;
      Timeline timeline3 = timeline1;
      if (seasonNumber != 13)
        return (ActionResult<Timeline>) timeline3;
      int num1;
      if (buildVersion < 13.30M)
      {
        if (buildVersion < 13.10M)
        {
          if (buildVersion >= 13.00M)
          {
            num1 = 7;
            goto label_10;
          }
        }
        else if (buildVersion >= 13.20M)
        {
          num1 = 6;
          goto label_10;
        }
        num1 = 7;
      }
      else
        num1 = buildVersion < 13.40M ? 4 : 0;
label_10:
      int num2 = num1;
      timeline3.Channels["client-events"].States[0].ActiveEvents.Add(new ChannelEvent(string.Format("EventFlag.WL{0}", (object) num2)));
      return (ActionResult<Timeline>) timeline3;
    }
  }
}
