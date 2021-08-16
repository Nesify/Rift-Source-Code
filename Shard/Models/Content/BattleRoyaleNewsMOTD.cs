// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.BattleRoyaleNewsMOTD
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Content
{
  public class BattleRoyaleNewsMOTD : PagesMOTD
  {
    public BattleRoyaleNewsMOTD(
      string title,
      string body,
      string image,
      string tileImage,
      string type = "Text")
      : base(title, body, type)
    {
      this.Image = image;
      this.TileImage = tileImage;
    }

    [JsonProperty("image")]
    public string Image { get; set; }

    [JsonProperty("tileImage")]
    public string TileImage { get; set; }
  }
}
