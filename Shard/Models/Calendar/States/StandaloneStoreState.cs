// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Calendar.States.StandaloneStoreState
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;
using System;

namespace Rift.Backend.Models.Calendar.States
{
  public class StandaloneStoreState
  {
    [JsonProperty("activePurchaseLimitingEventIds")]
    public string[] ActivePurchaseLimitingEventIds => Array.Empty<string>();

    [JsonProperty("storefront")]
    public object Storefront => new object();

    [JsonProperty("rmtPromotionConfig")]
    public string[] RMTPromotionConfig => Array.Empty<string>();

    [JsonProperty("storeEnd")]
    public DateTime StoreEnd => DateTime.MinValue;
  }
}
