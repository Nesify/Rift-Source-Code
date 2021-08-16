// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Failsafe.WrongButtonException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
