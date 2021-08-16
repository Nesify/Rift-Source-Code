// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.FirstTimeSetup.FtsWelcome
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rift.Frontend.Pages.FirstTimeSetup
{
  public class FtsWelcome : ComponentBase
  {
    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "fts-page");
      __builder.AddAttribute(2, "id", "fts-welcome");
      __builder.AddMarkupContent(3, "\r\n    ");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "image");
      __builder.AddMarkupContent(6, "\r\n");
      for (int index = 0; index < 5; ++index)
      {
        __builder.AddContent(7, "            ");
        __builder.OpenElement(8, "img");
        __builder.AddAttribute(9, "src", "img/fts/rift_" + index.ToString() + "@.png");
        __builder.AddAttribute(10, "alt", "Rift " + index.ToString());
        __builder.CloseElement();
        __builder.AddMarkupContent(11, "\r\n");
      }
      __builder.AddContent(12, "    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(13, "\r\n    ");
      __builder.AddMarkupContent(14, "<div class=\"text\">\r\n        <h1>Welcome to Rift</h1>\r\n        <h3>It seems that you're new to Rift. Let's get you started.</h3>\r\n    </div>\r\n");
      __builder.CloseElement();
    }
  }
}
