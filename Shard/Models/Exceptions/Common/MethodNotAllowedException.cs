// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Common.MethodNotAllowedException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
