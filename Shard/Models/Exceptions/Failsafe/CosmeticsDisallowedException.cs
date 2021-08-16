// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Failsafe.CosmeticsDisallowedException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
