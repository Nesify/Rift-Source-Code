// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Fortnite.PrivacySettings
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;

namespace Rift.Backend.Models.Fortnite
{
  public class PrivacySettings
  {
    [JsonProperty("accountId")]
    public string AccountId { get; set; }

    [JsonProperty("optOutOfPublicLeaderboards")]
    public bool OptOutOfPublicLeaderboards => false;

    public PrivacySettings(string accountId) => this.AccountId = accountId;
  }
}
