// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Profile.CommonCoreProfileStats
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Newtonsoft.Json;
using System;

namespace Rift.Backend.Models.Profile
{
  public class CommonCoreProfileStats
  {
    [JsonProperty("survey_data")]
    public object SurveyData => (object) new
    {
      allSurveysMetadata = new{  },
      metadata = new{  }
    };

    [JsonProperty("personal_offers")]
    public object PersonalOffers => (object) new{  };

    [JsonProperty("intro_game_played")]
    public bool IntroGamePlayed => true;

    [JsonProperty("mtx_affiliate")]
    public string MtxAffiliate => "";

    [JsonProperty("mtx_affiliate_set_time")]
    public DateTime MtxAffiliateSetTime => DateTime.UtcNow.AddDays(-1.0);

    [JsonProperty("mtx_purchase_history")]
    public object MtxPurchaseHistory => (object) new
    {
      refundsUsed = 0,
      refundCredits = 99,
      purchases = Array.Empty<string>()
    };

    [JsonProperty("undo_cooldowns")]
    public string[] UndoCooldowns => Array.Empty<string>();

    [JsonProperty("in_app_purchases")]
    public object InAppPurchases => (object) new{  };

    [JsonProperty("import_friends_claimed")]
    public object ImportFriendsClaimed => (object) new{  };

    [JsonProperty("inventory_limit_bonus")]
    public int InventoryLimitBonus => 0;

    [JsonProperty("current_mtx_platform")]
    public string CurrentMtxPlatform => "EpicPC";

    [JsonProperty("daily_purchases")]
    public object DailyPurchases => (object) new
    {
      lastInterval = DateTime.UtcNow,
      purchaseList = new{  }
    };

    [JsonProperty("weekly_purchases")]
    public object WeeklyPurchases => (object) new
    {
      lastInterval = DateTime.UtcNow,
      purchaseList = new{  }
    };

    [JsonProperty("monthly_purchases")]
    public object MonthlyPurchases => (object) new
    {
      lastInterval = DateTime.UtcNow,
      purchaseList = new{  }
    };

    [JsonProperty("ban_history")]
    public object BanHistory => (object) new{  };

    [JsonProperty("undo_timeout")]
    public DateTime UndoTimeout => DateTime.UtcNow.AddDays(-7.0);

    [JsonProperty("permissions")]
    public string[] Permissions => Array.Empty<string>();

    [JsonProperty("mfa_enabled")]
    public bool MfaEnabled => true;

    [JsonProperty("allowed_to_send_gifts")]
    public bool AllowedToSendGifts => false;

    [JsonProperty("allowed_to_receive_gifts")]
    public bool AllowedToReceiveGifts => false;

    [JsonProperty("gift_history")]
    public object GiftHistory => (object) new
    {
      numSent = 0,
      sentTo = new{  },
      num_received = 0,
      receivedFrom = new{  },
      gifts = Array.Empty<object>()
    };
  }
}
