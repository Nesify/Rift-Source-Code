// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.OAuth.InvalidClientException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
