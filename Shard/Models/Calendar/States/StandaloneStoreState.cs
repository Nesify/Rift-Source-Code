// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Calendar.States.StandaloneStoreState
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
