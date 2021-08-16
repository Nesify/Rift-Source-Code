// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Models.Config.Configuration
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rift.Frontend.Models.Config
{
  public class Configuration
  {
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("launchArgs")]
    public string LaunchArgs { get; set; } = string.Empty;

    [JsonPropertyName("installs")]
    public List<Installation> Installations { get; set; } = new List<Installation>();
  }
}
