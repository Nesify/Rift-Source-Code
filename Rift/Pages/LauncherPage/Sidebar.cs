// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.LauncherPage.Sidebar
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Rift.Frontend.Utilities;

namespace Rift.Frontend.Pages.LauncherPage
{
  public class Sidebar : ComponentBase
  {
    public static bool ModsTabEnabled = true;
    public static string PlayText = "Play";
    public static string SettingsText = "Settings";
    public static string InfoText = "Info";
    public static string ModsText = "Mods";
    public static string WarningText = "Warning";

    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "ul");
      __builder.AddAttribute(1, "class", "sidebar");
      __builder.AddMarkupContent(2, "\n    ");
      __builder.AddMarkupContent(3, "<div class=\"rift-header\">\n        <img src=\"/img/rift.png\" alt=\"Icon\">\n        <h1>Rift</h1>\n    </div>\n    ");
      __builder.OpenElement(4, "li");
      __builder.AddAttribute(5, "id", "play-li");
      __builder.AddAttribute(6, "class", "selected");
      __builder.AddAttribute(7, "onclick", "rift.tabManager.setTab('play')");
      __builder.AddMarkupContent(8, "\n        <i class=\"fas fa-play\"></i>");
      __builder.AddContent(9, Sidebar.PlayText);
      __builder.AddMarkupContent(10, "\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(11, "\n    ");
      __builder.OpenElement(12, "li");
      __builder.AddAttribute(13, "id", "settings-li");
      __builder.AddAttribute(14, "onclick", "rift.tabManager.setTab('settings')");
      __builder.AddMarkupContent(15, "\n        <i class=\"fas fa-cog\"></i>");
      __builder.AddContent(16, Sidebar.SettingsText);
      __builder.AddMarkupContent(17, "\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(18, "\n");
      if (Sidebar.ModsTabEnabled)
      {
        __builder.AddContent(19, "        ");
        __builder.OpenElement(20, "li");
        __builder.AddAttribute(21, "id", "mods-li");
        __builder.AddAttribute(22, "onclick", "rift.tabManager.setTab('mods'); rift.modsLanding.animations.intro()");
        __builder.AddMarkupContent(23, "\n            <i class=\"fas fa-box-open\"></i>");
        __builder.AddContent(24, Sidebar.ModsText);
        __builder.AddMarkupContent(25, "\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(26, "\n");
      }
      __builder.AddContent(27, "    ");
      __builder.OpenElement(28, "li");
      __builder.AddAttribute(29, "id", "info-li");
      __builder.AddAttribute(30, "onclick", "rift.tabManager.setTab('info')");
      __builder.AddMarkupContent(31, "\n        <i class=\"fas fa-info\"></i>");
      __builder.AddContent(32, Sidebar.InfoText);
      __builder.AddMarkupContent(33, "\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(34, "\n");
      if (EmergencyNotice.Enabled)
      {
        __builder.AddContent(35, "        ");
        __builder.OpenElement(36, "li");
        __builder.AddAttribute(37, "id", "emergency-li");
        __builder.AddAttribute(38, "class", "warn");
        __builder.AddAttribute(39, "onclick", "rift.modalManager.showModal('emergency')");
        __builder.AddMarkupContent(40, "\n            <i class=\"fas fa-exclamation-triangle\"></i>");
        __builder.AddContent(41, Sidebar.WarningText);
        __builder.AddMarkupContent(42, "\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(43, "\n");
      }
      __builder.AddMarkupContent(44, "    \n");
      __builder.CloseElement();
    }
  }
}
