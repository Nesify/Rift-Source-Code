// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Common.NotFoundException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

namespace Rift.Backend.Models.Exceptions.Common
{
  internal class NotFoundException : BaseException
  {
    public NotFoundException()
      : base(1004, "Sorry the resource you were trying to find could not be found")
    {
      this.Status = 404;
    }
  }
}
