// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Common.UnhandledErrorException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

namespace Rift.Backend.Models.Exceptions.Common
{
  internal class UnhandledErrorException : BaseException
  {
    public UnhandledErrorException(string message)
      : base(1012, "Sorry, an error occurred and we were unable to resolve it. Error: {0}", message)
    {
      this.Status = 500;
    }
  }
}
