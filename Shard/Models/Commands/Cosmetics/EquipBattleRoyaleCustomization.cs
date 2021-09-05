// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Commands.Cosmetics.EquipBattleRoyaleCustomization
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

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
