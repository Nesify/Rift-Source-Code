// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Models.Nitestats
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using Newtonsoft.Json;

namespace Rift.Frontend.Models
{
  public static class Nitestats
  {
    public class FlToken
    {
      [JsonProperty("version")]
      public string Version { get; set; }

      [JsonProperty("fltoken")]
      public string Token { get; set; }
    }
  }
}
