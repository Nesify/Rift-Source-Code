// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Commands.Cosmetics.EquipBattleRoyaleCustomization
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using Rift.Backend.Models.Profile;
using System.Collections.Generic;

namespace Rift.Backend.Models.Commands.Cosmetics
{
  public class EquipBattleRoyaleCustomization
  {
    [JsonRequired]
    [JsonProperty("slotName")]
    public CosmeticLockerItemCategories SlotName { get; set; }

    [JsonRequired]
    [JsonProperty("itemToSlot")]
    public string ItemToSlot { get; set; }

    [JsonProperty("indexWithinSlot")]
    public int IndexWithinSlot { get; set; }

    [JsonProperty("variantUpdates")]
    public List<ItemVariant> VariantUpdates { get; set; }
  }
}
