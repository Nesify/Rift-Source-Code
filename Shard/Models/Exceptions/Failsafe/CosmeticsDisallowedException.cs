// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Failsafe.CosmeticsDisallowedException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

namespace Rift.Backend.Models.Exceptions.Failsafe
{
  internal class CosmeticsDisallowedException : BaseException
  {
    public CosmeticsDisallowedException()
      : base(19002, "Rift does not natively support cosmetics due to legal and ethical concerns.")
    {
      this.Status = 403;
    }
  }
}
