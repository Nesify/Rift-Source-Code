// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Utilities.ConsoleCommands
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

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
