// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Commands.Cosmetics.SetCosmeticLockerSlot
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using Rift.Backend.Models.Profile;
using System.Collections.Generic;

namespace Rift.Backend.Models.Commands.Cosmetics
{
  public class SetCosmeticLockerSlot
  {
    [JsonRequired]
    [JsonProperty("lockerItem")]
    public string LockerItem { get; set; }

    [JsonRequired]
    [JsonProperty("category")]
    public CosmeticLockerItemCategories Category { get; set; }

    [JsonProperty("itemToSlot")]
    public string ItemToSlot { get; set; }

    [JsonProperty("slotIndex")]
    public int SlotIndex { get; set; }

    [JsonProperty("variantUpdates")]
    public List<ItemVariant> VariantUpdates { get; set; }
  }
}
