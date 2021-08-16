// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Exceptions.RuntimeException
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

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
