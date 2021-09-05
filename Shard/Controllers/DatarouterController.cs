// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Controllers.DatarouterController
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Microsoft.AspNetCore.Mvc;

namespace Rift.Backend.Controllers
{
  [Route("[controller]/api/v1/public/data")]
  [ApiController]
  public class DatarouterController : ControllerBase
  {
    public ActionResult PostDatarouter() => (ActionResult) this.NoContent();
  }
}
