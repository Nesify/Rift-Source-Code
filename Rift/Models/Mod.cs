// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Models.Mod
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using System.Text.Json.Serialization;

namespace Rift.Frontend.Models
{
  public class Mod
  {
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("author")]
    public string Author { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("paks")]
    public string[] Paks { get; set; }

    [JsonIgnore]
    public string Icon { get; set; }
  }
}
