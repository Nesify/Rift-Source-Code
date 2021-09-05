// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.FirstTimeSetup.FtsWelcome
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

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
      __builder.AddMarkupContent(3, "\n    ");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "image");
      __builder.AddMarkupContent(6, "\n");
      for (int index = 0; index < 5; ++index)
      {
        __builder.AddContent(7, "            ");
        __builder.OpenElement(8, "img");
        __builder.AddAttribute(9, "src", "img/fts/rift_" + index.ToString() + "@.png");
        __builder.AddAttribute(10, "alt", "Rift " + index.ToString());
        __builder.CloseElement();
        __builder.AddMarkupContent(11, "\n");
      }
      __builder.AddContent(12, "    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(13, "\n    ");
      __builder.AddMarkupContent(14, "<div class=\"text\">\n        <h1>Welcome to Rift</h1>\n        <h3>It seems that you're new to Rift. Let's get you started.</h3>\n    </div>\n");
      __builder.CloseElement();
    }
  }
}
