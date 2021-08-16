// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Utilities.ConsoleCommands
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using Microsoft.JSInterop;
using System.Threading.Tasks;


#nullable enable
namespace Rift.Frontend.Utilities
{
  public static class ConsoleCommands
  {
    [JSInvokable("hammer")]
    public static async 
    #nullable disable
    Task Hammer() => await Rift.Frontend.Utilities.Hammer.Patch();
  }
}
