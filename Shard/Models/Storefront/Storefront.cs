// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Storefront.Storefront
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

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
