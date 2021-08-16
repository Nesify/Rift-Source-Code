// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.LauncherPage.Sidebar
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

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
      __builder.AddMarkupContent(2, "\r\n    ");
      __builder.AddMarkupContent(3, "<div class=\"rift-header\">\r\n        <img src=\"/img/rift.png\" alt=\"Icon\">\r\n        <h1>Rift</h1>\r\n    </div>\r\n    ");
      __builder.OpenElement(4, "li");
      __builder.AddAttribute(5, "id", "play-li");
      __builder.AddAttribute(6, "class", "selected");
      __builder.AddAttribute(7, "onclick", "rift.tabManager.setTab('play')");
      __builder.AddMarkupContent(8, "\r\n        <i class=\"fas fa-play\"></i>");
      __builder.AddContent(9, Sidebar.PlayText);
      __builder.AddMarkupContent(10, "\r\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(11, "\r\n    ");
      __builder.OpenElement(12, "li");
      __builder.AddAttribute(13, "id", "settings-li");
      __builder.AddAttribute(14, "onclick", "rift.tabManager.setTab('settings')");
      __builder.AddMarkupContent(15, "\r\n        <i class=\"fas fa-cog\"></i>");
      __builder.AddContent(16, Sidebar.SettingsText);
      __builder.AddMarkupContent(17, "\r\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(18, "\r\n");
      if (Sidebar.ModsTabEnabled)
      {
        __builder.AddContent(19, "        ");
        __builder.OpenElement(20, "li");
        __builder.AddAttribute(21, "id", "mods-li");
        __builder.AddAttribute(22, "onclick", "rift.tabManager.setTab('mods'); rift.modsLanding.animations.intro()");
        __builder.AddMarkupContent(23, "\r\n            <i class=\"fas fa-box-open\"></i>");
        __builder.AddContent(24, Sidebar.ModsText);
        __builder.AddMarkupContent(25, "\r\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(26, "\r\n");
      }
      __builder.AddContent(27, "    ");
      __builder.OpenElement(28, "li");
      __builder.AddAttribute(29, "id", "info-li");
      __builder.AddAttribute(30, "onclick", "rift.tabManager.setTab('info')");
      __builder.AddMarkupContent(31, "\r\n        <i class=\"fas fa-info\"></i>");
      __builder.AddContent(32, Sidebar.InfoText);
      __builder.AddMarkupContent(33, "\r\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(34, "\r\n");
      if (EmergencyNotice.Enabled)
      {
        __builder.AddContent(35, "        ");
        __builder.OpenElement(36, "li");
        __builder.AddAttribute(37, "id", "emergency-li");
        __builder.AddAttribute(38, "class", "warn");
        __builder.AddAttribute(39, "onclick", "rift.modalManager.showModal('emergency')");
        __builder.AddMarkupContent(40, "\r\n            <i class=\"fas fa-exclamation-triangle\"></i>");
        __builder.AddContent(41, Sidebar.WarningText);
        __builder.AddMarkupContent(42, "\r\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(43, "\r\n");
      }
      __builder.AddMarkupContent(44, "    \r\n");
      __builder.CloseElement();
    }
  }
}
