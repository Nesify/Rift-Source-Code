// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.Static.Watermark
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Rift.Frontend.Utilities;

namespace Rift.Frontend.Pages.Static
{
  public class Watermark : ComponentBase
  {
    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "watermark");
      __builder.AddAttribute(2, "onclick", "rift.tabManager.setTab('info')");
      __builder.AddMarkupContent(3, "\n    ");
      __builder.AddContent(4, Strings.VERSION_STRING);
      __builder.AddMarkupContent(5, "\n");
      __builder.CloseElement();
    }
  }
}
