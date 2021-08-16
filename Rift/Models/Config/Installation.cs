// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Models.Config.Installation
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using System.Text.Json.Serialization;

namespace Rift.Frontend.Models.Config
{
  public class Installation
  {
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("id")]
    public string Id => this.Name.ToLower().Replace(" ", "-");
  }
}
