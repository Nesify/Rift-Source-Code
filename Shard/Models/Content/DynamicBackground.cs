// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Content.DynamicBackground
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Content
{
  public class DynamicBackground : BasePagesEntry
  {
    public DynamicBackground()
      : base("dynamicbackgrounds")
    {
    }

    [JsonProperty("backgrounds", Order = -7)]
    public Background Backgrounds { get; set; }
  }
}
