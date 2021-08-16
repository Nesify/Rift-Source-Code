// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Controllers.LightswitchController
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Microsoft.AspNetCore.Mvc;
using Rift.Backend.Models.Lightswitch;
using System.Collections.Generic;

namespace Rift.Backend.Controllers
{
  [Route("[controller]/api/service/bulk/status")]
  [ApiController]
  public class LightswitchController : ControllerBase
  {
    public ActionResult<List<LightswitchStatus>> GetLightswitchStatus(
      [FromQuery] string serviceId)
    {
      return (ActionResult<List<LightswitchStatus>>) new List<LightswitchStatus>()
      {
        new LightswitchStatus(serviceId.ToLower())
      };
    }
  }
}
