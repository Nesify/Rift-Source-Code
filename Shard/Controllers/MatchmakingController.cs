// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Controllers.MatchmakingController
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Microsoft.AspNetCore.Mvc;
using Rift.Backend.Models.Exceptions.Failsafe;
using System.Threading.Tasks;

namespace Rift.Backend.Controllers
{
  [Route("/fortnite/api/game/v2/matchmakingservice/ticket/player/{playerId}")]
  [ApiController]
  public class MatchmakingController : ControllerBase
  {
    [HttpGet]
    public Task<ActionResult> Get(string playerId) => throw new WrongButtonException();
  }
}
