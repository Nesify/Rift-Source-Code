// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.Static.Watermark
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

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
      __builder.AddMarkupContent(3, "\r\n    ");
      __builder.AddContent(4, Strings.VERSION_STRING);
      __builder.AddMarkupContent(5, "\r\n");
      __builder.CloseElement();
    }
  }
}
