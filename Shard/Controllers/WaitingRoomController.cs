﻿// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Controllers.WaitingRoomController
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Microsoft.AspNetCore.Mvc;

namespace Rift.Backend.Controllers
{
  [Route("[controller]/api/waitingroom")]
  [ApiController]
  public class WaitingRoomController : ControllerBase
  {
    public ActionResult GetWaitingRoom() => (ActionResult) this.NoContent();
  }
}
