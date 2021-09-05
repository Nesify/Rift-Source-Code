// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Models.Nitestats
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

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
