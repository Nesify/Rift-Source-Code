// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Models.Config.Configuration
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

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
