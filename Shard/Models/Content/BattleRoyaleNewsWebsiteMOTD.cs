// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.BattleRoyaleNewsWebsiteMOTD
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

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
