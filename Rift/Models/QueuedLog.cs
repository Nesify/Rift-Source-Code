// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Models.QueuedLog
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

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
