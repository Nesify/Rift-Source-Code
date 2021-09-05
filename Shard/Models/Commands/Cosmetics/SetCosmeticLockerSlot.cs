// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Commands.Cosmetics.SetCosmeticLockerSlot
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

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
