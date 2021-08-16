// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Commands.Cosmetics.SetCosmeticLockerBanner
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
