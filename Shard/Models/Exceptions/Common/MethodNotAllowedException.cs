// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Common.MethodNotAllowedException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

namespace Rift.Backend.Models.Exceptions.Common
{
  internal class MethodNotAllowedException : BaseException
  {
    public MethodNotAllowedException()
      : base(1009, "Sorry the resource you were trying to access cannot be accessed with the HTTP method you used.")
    {
      this.Status = 405;
    }
  }
}
