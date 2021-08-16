// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Fortnite.AthenaLockerSlot
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using Rift.Backend.Models.Profile;
using System.Collections.Generic;

namespace Rift.Backend.Models.Fortnite
{
  public class AthenaLockerSlot
  {
    [JsonProperty("items")]
    public string[] Items { get; set; }

    [JsonProperty("activeVariants", NullValueHandling = NullValueHandling.Ignore)]
    public List<AthenaLockerSlotActiveVariant> ActiveVariants { get; set; }

    public AthenaLockerSlot(List<ItemVariant> variants = null, params string[] items)
    {
      this.Items = items;
      if (variants == null)
        return;
      this.ActiveVariants = new List<AthenaLockerSlotActiveVariant>()
      {
        new AthenaLockerSlotActiveVariant(variants)
      };
    }
  }
}
