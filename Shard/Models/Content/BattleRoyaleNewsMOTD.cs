// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.BattleRoyaleNewsMOTD
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

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
