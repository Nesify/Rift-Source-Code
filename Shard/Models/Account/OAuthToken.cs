// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Account.OAuthToken
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;
using System;

namespace Rift.Backend.Models.Account
{
  public class OAuthToken
  {
    [JsonProperty("access_token")]
    public string AccessToken => Tools.CreateRandomHexString();

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("expires_at")]
    public DateTime ExpiresAt { get; set; }

    [JsonProperty("token_type")]
    public string TokenType => "bearer";

    [JsonProperty("refresh_token", NullValueHandling = NullValueHandling.Ignore)]
    public string RefreshToken { get; set; }

    [JsonProperty("refresh_expires", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int RefreshExpires { get; set; }

    [JsonProperty("refresh_expires_at", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime RefreshExpiresAt { get; set; }

    [JsonProperty("account_id", NullValueHandling = NullValueHandling.Ignore)]
    public string AccountId { get; set; }

    [JsonProperty("client_id")]
    public string ClientId { get; set; }

    [JsonProperty("internal_client")]
    public bool InternalClient => true;

    [JsonProperty("client_service")]
    public string ClientService => "fortnite";

    [JsonProperty("scope", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string[] Scope { get; set; }

    [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
    public string DisplayName { get; set; }

    [JsonProperty("app", NullValueHandling = NullValueHandling.Ignore)]
    public string App { get; set; }

    [JsonProperty("in_app_id", NullValueHandling = NullValueHandling.Ignore)]
    public string InAppId { get; set; }

    public OAuthToken(string clientId)
    {
      this.ExpiresIn = 14400;
      this.ExpiresAt = DateTime.UtcNow.AddHours(4.0);
      this.ClientId = clientId;
    }

    public OAuthToken(string clientId, string id, string displayName)
    {
      this.ExpiresIn = 28800;
      this.ExpiresAt = DateTime.UtcNow.AddHours(8.0);
      this.RefreshToken = Tools.CreateRandomHexString();
      this.RefreshExpires = 86400;
      this.RefreshExpiresAt = DateTime.UtcNow.AddDays(1.0);
      this.AccountId = id;
      this.ClientId = clientId;
      this.Scope = Array.Empty<string>();
      this.DisplayName = displayName;
      this.App = "fortnite";
      this.InAppId = id;
    }
  }
}
