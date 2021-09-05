// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.PagesMessage
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Content
{
  public class PagesMessage
  {
    [JsonProperty("_type")]
    public string Type => "CommonUI Simple Message";

    [JsonProperty("message")]
    public PagesMessageBase Message { get; set; }

    public PagesMessage(string title, string body, string image = null, string adspace = null) => this.Message = new PagesMessageBase(title, body, image, adspace);
  }
}
