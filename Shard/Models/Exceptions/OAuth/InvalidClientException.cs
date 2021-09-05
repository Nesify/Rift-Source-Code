// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.OAuth.InvalidClientException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

namespace Rift.Backend.Models.Exceptions.OAuth
{
  internal class InvalidClientException : BaseException
  {
    public InvalidClientException()
      : base(1011, "It appears that your Authorization header may be invalid or not present, please verify that you are sending the correct headers.")
    {
      this.Status = 400;
    }
  }
}
