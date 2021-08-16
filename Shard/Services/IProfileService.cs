// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Services.IProfileService
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
