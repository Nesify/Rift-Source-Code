// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Storefront.Catalog
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Rift.Backend.Models.Storefront
{
  public class Catalog
  {
    public Catalog() => this.Storefronts = new List<Rift.Backend.Models.Storefront.Storefront>()
    {
      new Rift.Backend.Models.Storefront.Storefront("BRDailyStorefront"),
      new Rift.Backend.Models.Storefront.Storefront("BRWeeklyStorefront")
    };

    [JsonProperty("refreshIntervalHrs")]
    public int RefreshIntervalHrs => 24;

    [JsonProperty("dailyPurchaseHrs")]
    public int DailyPurchaseHrs => 24;

    [JsonProperty("expiration")]
    public DateTime Expiration => DateTime.MaxValue;

    [JsonProperty("storefronts")]
    public List<Rift.Backend.Models.Storefront.Storefront> Storefronts { get; set; }
  }
}
