// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.Changes.McpItemAttrChanged
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
