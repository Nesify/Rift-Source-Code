// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.LauncherPage.Tabs.ModsTab.ModsTab
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

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
      __builder.AddMarkupContent(2, "\n\n");
      __builder.AddMarkupContent(3, "<div id=\"mods-page\" style=\"display: none;\">\n    <div class=\"mods-intro scale-in\">\n        <canvas id=\"confetti-canvas\" style=\"width: 100%; height: 100%\"></canvas>\n        <div class=\"icon\">\n            <i id=\"closedbox\" class=\"fas fa-box\"></i>\n            <i id=\"openbox\" class=\"fas fa-box-open\"></i>\n            <div class=\"explosion-circle\"></div>\n        </div>\n        <div class=\"text\">\n            <h1>Rift Mods</h1>\n            <h3>Coming soon</h3>\n        </div>\n    </div>\n</div>");
    }

    [Inject]
    private UpdateService _updateService { get; set; }
  }
}
