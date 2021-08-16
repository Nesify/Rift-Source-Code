// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.BattleRoyaleNewsWebsiteMOTD
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Content
{
  public class BattleRoyaleNewsWebsiteMOTD : BattleRoyaleNewsMOTD
  {
    public BattleRoyaleNewsWebsiteMOTD(
      string title,
      string body,
      string image,
      string tileImage,
      string website,
      string websiteText = null)
      : base(title, body, image, tileImage, "Website")
    {
      this.WebsiteURL = website;
      this.WebsiteButtonText = websiteText;
    }

    [JsonProperty("websiteURL")]
    public string WebsiteURL { get; set; }

    [JsonProperty("websiteButtonText")]
    public string WebsiteButtonText { get; set; }
  }
}
