// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.FirstTimeSetup.FtsPage
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rift.Frontend.Pages.FirstTimeSetup
{
  public class FtsPage : ComponentBase
  {
    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "center-container");
      __builder.AddMarkupContent(2, "\n    ");
      __builder.OpenComponent<FtsWelcome>(3);
      __builder.CloseComponent();
      __builder.AddMarkupContent(4, "\n    ");
      __builder.OpenComponent<FtsName>(5);
      __builder.CloseComponent();
      __builder.AddMarkupContent(6, "\n    ");
      __builder.OpenComponent<FtsBuild>(7);
      __builder.CloseComponent();
      __builder.AddMarkupContent(8, "\n    ");
      __builder.AddMarkupContent(9, "<div class=\"fts-page\" id=\"fts-final\" style=\"display: none\">\n        <div class=\"text\">\n            <h1>All done!</h1>\n            <h3>Enjoy Rift!</h3>\n        </div>\n    </div>\n");
      __builder.CloseElement();
    }
  }
}
