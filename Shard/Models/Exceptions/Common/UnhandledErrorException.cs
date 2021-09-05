// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Common.UnhandledErrorException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

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
