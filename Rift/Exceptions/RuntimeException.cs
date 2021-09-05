// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Exceptions.RuntimeException
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using System;

namespace Rift.Frontend.Exceptions
{
  public class RuntimeException : Exception
  {
    public RuntimeException()
      : base("Failed to start Runtime!")
    {
    }
  }
}
