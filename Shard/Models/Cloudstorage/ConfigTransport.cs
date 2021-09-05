// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Cloudstorage.ConfigTransport
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

namespace Rift.Backend.Models.Cloudstorage
{
  public class ConfigTransport
  {
    public ConfigTransport(string name, string type, bool isEnabled, int priority)
    {
      this.Name = name;
      this.Type = type;
      this.IsEnabled = isEnabled;
      this.IsRequired = isEnabled;
      this.IsPrimary = isEnabled;
      this.Priority = priority;
    }

    public string Name { get; set; }

    public string Type { get; set; }

    public string AppName => "Fortnite";

    public bool IsEnabled { get; set; }

    public bool IsRequired { get; set; }

    public bool IsPrimary { get; set; }

    public int TimeoutSeconds => 30;

    public int Priority { get; set; }
  }
}
