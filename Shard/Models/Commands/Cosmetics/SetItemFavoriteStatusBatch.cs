// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Commands.Cosmetics.SetItemFavoriteStatusBatch
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Rift.Backend.Models.Commands.Cosmetics
{
  public class SetItemFavoriteStatusBatch
  {
    [JsonRequired]
    [JsonProperty("itemIds")]
    public List<string> ItemIds { get; set; }

    [JsonRequired]
    [JsonProperty("itemFavStatus")]
    public List<bool> ItemFavStatus { get; set; }
  }
}
