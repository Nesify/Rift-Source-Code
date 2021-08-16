// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Lightswitch.LightswitchStatus
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;

namespace Rift.Backend.Models.Lightswitch
{
  public class LightswitchStatus
  {
    [JsonProperty("banned")]
    public bool Banned;
    [JsonProperty("maintenanceUrl")]
    public string MaintenanceUrl;
    [JsonProperty("overrideCatalogIds")]
    public string[] OverrideCatalogIds = new string[1]
    {
      "a7f138b2e51945ffbfdacc1af0541053"
    };

    [JsonProperty("serviceInstanceId")]
    public string ServiceInstanceId { get; set; }

    [JsonProperty("status")]
    public string Status => "UP";

    [JsonProperty("message")]
    public string Message => "Fortnite is UP";

    [JsonProperty("allowedActions")]
    public string[] AllowedActions => Array.Empty<string>();

    [JsonProperty("launcherInfoDTO")]
    public LauncherInfo LauncherInfoDTO => new LauncherInfo();

    public LightswitchStatus(string serviceId) => this.ServiceInstanceId = serviceId;
  }
}
