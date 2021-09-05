// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Services.RichPresenceService
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using DiscordRPC;
using DiscordRPC.Events;
using DiscordRPC.Message;
using Rift.Frontend.Enums;
using Rift.Frontend.Models.Config;
using Rift.Frontend.Utilities;

namespace Rift.Frontend.Services
{
  public class RichPresenceService
  {
    public static bool EnableRichPresence = true;
    public static bool ShowBuildNameInRichPresence = true;
    private readonly DiscordRpcClient _client;

    public RichPresenceService()
    {
      if (!RichPresenceService.EnableRichPresence)
        return;
      Logger.Log("Initializing Discord Rich Presence", LogCategory.RichPresenceService);
      this._client = new DiscordRpcClient("870728812860698694");
      this._client.OnReady += new OnReadyEvent(RichPresenceService.ClientOnOnReady);
      this._client.OnError += new OnErrorEvent(RichPresenceService.ClientOnOnError);
      this._client.Initialize();
      this._client.UpdateLargeAsset("rift", "Rift " + Strings.TRIMMED_VERSION_STRING);
      this.SetPlayingFortnite((Installation) null);
    }

    public void Ping()
    {
    }

    public void SetPlayingFortnite(Installation installation)
    {
      if (!RichPresenceService.EnableRichPresence)
        return;
      if (installation != null)
      {
        this._client.UpdateDetails(RichPresenceService.ShowBuildNameInRichPresence ? "Playing \"" + installation.Name + "\"" : "Playing Fortnite");
        this._client.UpdateStartTime();
      }
      else
      {
        this._client.UpdateDetails("In the launcher");
        this._client.UpdateClearTime();
      }
    }

    private static void ClientOnOnError(object sender, ErrorMessage args) => Logger.Log(string.Format("Discord RPC error: {0}: {1}", (object) args.Type, (object) args.Message), LogCategory.RichPresenceService, LogType.Error);

    private static void ClientOnOnReady(object sender, ReadyMessage args) => Logger.Log(string.Format("Initialized rich presence for {0}#{1}", (object) args.User.Username, (object) args.User.Discriminator), LogCategory.RichPresenceService);
  }
}
