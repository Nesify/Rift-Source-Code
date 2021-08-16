// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.PagesMessageBase
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Content
{
  public class PagesMessageBase
  {
    [JsonProperty("image")]
    public string Image { get; set; }

    [JsonProperty("hidden")]
    public bool IsHidden => false;

    [JsonProperty("_type")]
    public string Type => "CommonUI Simple Message Base";

    [JsonProperty("messagetype")]
    public string MessageType => "normal";

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("adspace", NullValueHandling = NullValueHandling.Ignore)]
    public string Adspace { get; set; }

    [JsonProperty("spotlight")]
    public bool IsSpotlight => false;

    public PagesMessageBase(string title, string body, string image = null, string adspace = null)
    {
      this.Title = title;
      this.Body = body;
      this.Image = image;
      this.Adspace = adspace;
    }
  }
}
