// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Commands.Cosmetics.SetCosmeticLockerBanner
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Commands.Cosmetics
{
  public class SetCosmeticLockerBanner
  {
    [JsonProperty("lockerItem")]
    [JsonRequired]
    public string LockerItem { get; set; }

    [JsonProperty("bannerColorTemplateName")]
    [JsonRequired]
    public string BannerColorTemplateName { get; set; }

    [JsonProperty("bannerIconTemplateName")]
    [JsonRequired]
    public string BannerIconTemplateName { get; set; }
  }
}
