// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.Cloudstorage.FileNotFoundException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

namespace Rift.Backend.Models.Exceptions.Cloudstorage
{
  internal class FileNotFoundException : BaseException
  {
    public FileNotFoundException(string file)
      : base(12004, "Sorry, we couldn't find a system file for {0}", file)
    {
      this.Status = 404;
    }
  }
}
