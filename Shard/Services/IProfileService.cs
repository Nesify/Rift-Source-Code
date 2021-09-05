// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Services.IProfileService
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

namespace Rift.Backend.Services
{
  public interface IProfileService
  {
    Rift.Backend.Models.Profile.Profile GenerateAthenaProfile(
      string id,
      int seasonNumber,
      string profileId = "athena");

    Rift.Backend.Models.Profile.Profile GenerateCommonCoreProfile(
      string id,
      string profileId = "common_core");

    Rift.Backend.Models.Profile.Profile GenerateBlankProfile(string id, string profileId);
  }
}
