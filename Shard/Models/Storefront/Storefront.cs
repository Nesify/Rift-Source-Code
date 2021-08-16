// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Storefront.Storefront
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;

namespace Rift.Backend.Models.Storefront
{
  public class Storefront
  {
    public Storefront(string name) => this.Name = name;

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("catalogEntries")]
    public object[] CatalogEntries => Array.Empty<object>();
  }
}
