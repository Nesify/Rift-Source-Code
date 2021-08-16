// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.BasePagesEntry
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;

namespace Rift.Backend.Models.Content
{
  public class BasePagesEntry
  {
    [JsonProperty("_title", Order = -8)]
    public string Title { get; set; }

    [JsonProperty("_activeDate", Order = -5)]
    public DateTime ActiveDate => DateTime.UtcNow.AddMonths(-12);

    [JsonProperty("lastModified", Order = -4)]
    public DateTime LastModified { get; set; }

    [JsonProperty("_locale", Order = -3)]
    public string Locale => "en-US";

    public BasePagesEntry(string title, DateTime? lastModified = null)
    {
      this.Title = title;
      this.LastModified = lastModified ?? DateTime.UtcNow;
    }
  }
}
