// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Failsafe.WrongButtonException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

namespace Rift.Backend.Models.Exceptions.Failsafe
{
  internal class WrongButtonException : BaseException
  {
    public WrongButtonException()
      : base(19001, "Press F3 to go in-game.")
    {
      this.Status = 404;
    }
  }
}
