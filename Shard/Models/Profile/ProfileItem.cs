// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.ProfileItem
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Profile
{
  public class ProfileItem
  {
    [JsonProperty("templateId")]
    public string TemplateId { get; set; }

    [JsonProperty("attributes")]
    public object Attributes { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    public ProfileItem(string templateId, object attributes = null, int quantity = 1)
    {
      this.TemplateId = templateId;
      this.Attributes = attributes ?? (object) new ItemAttributes();
      this.Quantity = quantity;
    }
  }
}
