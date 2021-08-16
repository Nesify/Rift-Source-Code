// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Enums.LogType
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using System.ComponentModel;

namespace Rift.Frontend.Enums
{
  public enum LogType
  {
    [Description("INFO")] Information,
    [Description("WARN")] Warning,
    [Description("FAIL")] Error,
    [Description("STOP")] Exception,
  }
}
