// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Models.QueuedLog
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Rift.Frontend.Enums;

namespace Rift.Frontend.Models
{
  public readonly struct QueuedLog
  {
    public readonly string Message;
    public readonly LogCategory Category;
    public readonly LogType Type;

    public QueuedLog(string message, LogCategory category, LogType type)
    {
      this.Message = message;
      this.Category = category;
      this.Type = type;
    }
  }
}
