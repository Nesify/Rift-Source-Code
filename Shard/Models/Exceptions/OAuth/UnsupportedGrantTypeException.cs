// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.OAuth.UnsupportedGrantTypeException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

namespace Rift.Backend.Models.Exceptions.OAuth
{
  internal class UnsupportedGrantTypeException : BaseException
  {
    public UnsupportedGrantTypeException(string grantType)
      : base(1013, "Unsupported grant type: " + grantType)
    {
      this.Status = 400;
    }
  }
}
