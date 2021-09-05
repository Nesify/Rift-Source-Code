// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.Changes.McpItemAttrChanged
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Profile.Changes
{
  public class McpItemAttrChanged : McpChange
  {
    [JsonProperty("itemId")]
    public string ItemId { get; set; }

    [JsonProperty("attributeName")]
    public string AttributeName { get; set; }

    [JsonProperty("attributeValue")]
    public object AttributeValue { get; set; }

    public McpItemAttrChanged(string itemId, string attributeName, object attributeValue)
      : base("itemAttrChanged")
    {
      this.ItemId = itemId;
      this.AttributeName = attributeName;
      this.AttributeValue = attributeValue;
    }
  }
}
