// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Common.NotFoundException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
