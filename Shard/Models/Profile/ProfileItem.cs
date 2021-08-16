// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.ProfileItem
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
