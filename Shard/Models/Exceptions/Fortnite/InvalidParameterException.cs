// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Fortnite.InvalidParameterException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

namespace Rift.Backend.Models.Exceptions.Fortnite
{
  internal class InvalidParameterException : BaseException
  {
    public InvalidParameterException()
      : base(16040, "itemIds and itemFavStatus must match in size")
    {
      this.Status = 400;
    }
  }
}
