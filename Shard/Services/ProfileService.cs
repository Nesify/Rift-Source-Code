// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Services.ProfileService
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Rift.Backend.Models.Fortnite;
using Rift.Backend.Models.Profile;
using System.Collections.Generic;

namespace Rift.Backend.Services
{
  public class ProfileService : IProfileService
  {
    public Rift.Backend.Models.Profile.Profile GenerateAthenaProfile(
      string id,
      int seasonNumber,
      string profileId = "athena")
    {
      ++Program.AthenaRvn;
      Rift.Backend.Models.Profile.Profile profile = new Rift.Backend.Models.Profile.Profile()
      {
        _Id = id,
        Id = id,
        Rvn = Program.AthenaRvn,
        ProfileId = profileId,
        Items = new Dictionary<string, object>(),
        Stats = new ProfileStats()
        {
          Attributes = (object) new AthenaProfileStats(seasonNumber)
        }
      };
      foreach (string whitelistedCosmetic in Program.WhitelistedCosmetics)
        profile.Items.Add(whitelistedCosmetic, (object) new ProfileItem(whitelistedCosmetic));
      profile.Items.Add("CosmeticLocker:cosmeticlocker_athena", (object) new ProfileItem("CosmeticLocker:cosmeticlocker_athena", (object) new AthenaCosmeticLocker()
      {
        LockerName = "Locker",
        BannerIcon = "",
        BannerColor = "",
        LockerSlotsData = new AthenaLockerSlotsData()
        {
          Slots = new Dictionary<string, AthenaLockerSlot>()
          {
            {
              "Character",
              new AthenaLockerSlot((List<ItemVariant>) null, new string[1]
              {
                Program.CosmeticLoadout["character"].ToString()
              })
            },
            {
              "Backpack",
              new AthenaLockerSlot((List<ItemVariant>) null, new string[1]
              {
                Program.CosmeticLoadout["backpack"].ToString()
              })
            },
            {
              "Pickaxe",
              new AthenaLockerSlot((List<ItemVariant>) null, new string[1]
              {
                Program.CosmeticLoadout["pickaxe"].ToString()
              })
            },
            {
              "Glider",
              new AthenaLockerSlot((List<ItemVariant>) null, new string[1]
              {
                Program.CosmeticLoadout["glider"].ToString()
              })
            },
            {
              "SkyDiveContrail",
              new AthenaLockerSlot((List<ItemVariant>) null, new string[1]
              {
                Program.CosmeticLoadout["skydivecontrail"].ToString()
              })
            },
            {
              "LoadingScreen",
              new AthenaLockerSlot((List<ItemVariant>) null, new string[1]
              {
                Program.CosmeticLoadout["loadingscreen"].ToString()
              })
            },
            {
              "MusicPack",
              new AthenaLockerSlot((List<ItemVariant>) null, new string[1]
              {
                Program.CosmeticLoadout["musicpack"].ToString()
              })
            },
            {
              "Dance",
              new AthenaLockerSlot((List<ItemVariant>) null, (string[]) Program.CosmeticLoadout["dance"])
            },
            {
              "ItemWrap",
              new AthenaLockerSlot((List<ItemVariant>) null, (string[]) Program.CosmeticLoadout["itemwrap"])
            }
          }
        }
      }));
      return profile;
    }

    public Rift.Backend.Models.Profile.Profile GenerateCommonCoreProfile(
      string id,
      string profileId = "common_core")
    {
      ++Program.CommonCoreRvn;
      return new Rift.Backend.Models.Profile.Profile()
      {
        _Id = id,
        Id = id,
        Rvn = Program.CommonCoreRvn,
        ProfileId = profileId,
        Items = new Dictionary<string, object>(),
        Stats = new ProfileStats()
        {
          Attributes = (object) new CommonCoreProfileStats()
        }
      };
    }

    public Rift.Backend.Models.Profile.Profile GenerateBlankProfile(
      string id,
      string profileId)
    {
      ++Program.CommonCoreRvn;
      return new Rift.Backend.Models.Profile.Profile()
      {
        _Id = id,
        Id = id,
        Rvn = Program.CommonCoreRvn,
        ProfileId = profileId,
        Items = new Dictionary<string, object>(),
        Stats = new ProfileStats()
        {
          Attributes = (object) new{  }
        }
      };
    }
  }
}
