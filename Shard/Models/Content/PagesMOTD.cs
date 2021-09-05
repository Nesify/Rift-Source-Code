// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.PagesMOTD
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Content
{
  public class PagesMOTD
  {
    [JsonProperty("entryType")]
    public string EntryType { get; set; }

    [JsonProperty("_type")]
    public string Type => "CommonUI Simple Message MOTD";

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("sortingPriority")]
    public int SortingPriority { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    public PagesMOTD(string title, string body, string type = "Text", int sortingPriority = 0, string id = null)
    {
      this.EntryType = type;
      this.Title = title;
      this.Body = body;
      this.SortingPriority = sortingPriority;
      this.Id = id ?? title;
    }
  }
}
