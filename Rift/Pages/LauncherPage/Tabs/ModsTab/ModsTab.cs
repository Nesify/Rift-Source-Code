// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.LauncherPage.Tabs.ModsTab.ModsTab
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Rift.Frontend.Services;

namespace Rift.Frontend.Pages.LauncherPage.Tabs.ModsTab
{
  public class ModsTab : ComponentBase
  {
    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "script");
      __builder.AddAttribute(1, "src", "https://cdn.jsdelivr.net/npm/canvas-confetti@1.4.0/dist/confetti.browser.min.js");
      __builder.CloseElement();
      __builder.AddMarkupContent(2, "\r\n\r\n");
      __builder.AddMarkupContent(3, "<div id=\"mods-page\" style=\"display: none;\">\r\n    <div class=\"mods-intro scale-in\">\r\n        <canvas id=\"confetti-canvas\" style=\"width: 100%; height: 100%\"></canvas>\r\n        <div class=\"icon\">\r\n            <i id=\"closedbox\" class=\"fas fa-box\"></i>\r\n            <i id=\"openbox\" class=\"fas fa-box-open\"></i>\r\n            <div class=\"explosion-circle\"></div>\r\n        </div>\r\n        <div class=\"text\">\r\n            <h1>Rift Mods</h1>\r\n            <h3>Coming soon</h3>\r\n        </div>\r\n    </div>\r\n</div>");
    }

    [Inject]
    private UpdateService _updateService { get; set; }
  }
}
