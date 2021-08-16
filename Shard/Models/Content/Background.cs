// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.Background
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rift.Backend.Models.Content
{
  public class Background
  {
    public Background(params BackgroundData[] backgrounds) => this.Backgrounds = ((IEnumerable<BackgroundData>) backgrounds).Select<BackgroundData, BackgroundData>((Func<BackgroundData, BackgroundData>) (x => new BackgroundData(x.Stage, x.Key))).ToList<BackgroundData>();

    [JsonProperty("backgrounds", Order = -7)]
    public List<BackgroundData> Backgrounds { get; set; }

    [JsonProperty("_type")]
    public string Type => "DynamicBackgroundList";
  }
}
