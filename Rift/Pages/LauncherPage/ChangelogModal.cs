// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.LauncherPage.ChangelogModal
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Rift.Frontend.Models;
using Rift.Frontend.Utilities;
using System;

namespace Rift.Frontend.Pages.LauncherPage
{
  public class ChangelogModal : ComponentBase
  {
    public static string ChangelogTitle = "What's new in Rift {0}";
    public static string ChangelogDiscordAd = "Join our Discord server for more updates!";

    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "modal minimized");
      __builder.AddAttribute(2, "id", "changelog-modal");
      __builder.AddMarkupContent(3, "\n    ");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "modal-window");
      __builder.AddAttribute(6, "style", "width: 490px");
      __builder.AddMarkupContent(7, "\n        ");
      __builder.AddMarkupContent(8, "<div class=\"close-button\" onclick=\"rift.modalManager.hideModal('changelog')\">\n            <i class=\"fas fa-times\"></i>\n        </div>\n        ");
      __builder.OpenElement(9, "div");
      __builder.AddAttribute(10, "class", "modal-header");
      __builder.AddMarkupContent(11, "\n            ");
      __builder.OpenElement(12, "h1");
      __builder.AddAttribute(13, "class", "modal-title");
      __builder.AddContent(14, string.Format(ChangelogModal.ChangelogTitle, (object) Strings.TRIMMED_VERSION_STRING));
      __builder.CloseElement();
      __builder.AddMarkupContent(15, "\n            ");
      __builder.OpenElement(16, "p");
      __builder.AddAttribute(17, "class", "modal-desc");
      __builder.AddContent(18, Constants.CHANGELOG.Description);
      __builder.CloseElement();
      __builder.AddMarkupContent(19, "\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(20, "\n\n        ");
      __builder.OpenElement(21, "div");
      __builder.AddAttribute(22, "class", "change-container");
      __builder.AddMarkupContent(23, "\n");
      foreach (ChangelogSection section in Constants.CHANGELOG.Sections)
      {
        __builder.AddContent(24, "                ");
        __builder.OpenElement(25, "div");
        __builder.AddAttribute(26, "class", "change-section");
        __builder.AddMarkupContent(27, "\n                    ");
        __builder.OpenElement(28, "h1");
        __builder.AddContent(29, section.Title);
        __builder.CloseElement();
        __builder.AddMarkupContent(30, "\n                    ");
        __builder.OpenElement(31, "ul");
        __builder.AddMarkupContent(32, "\n");
        foreach (ChangelogChange change in section.Changes)
        {
          __builder.AddContent(33, "                            ");
          __builder.OpenElement(34, "li");
          __builder.AddMarkupContent(35, "\n                                ");
          __builder.OpenElement(36, "strong");
          __builder.AddContent(37, change.Summary);
          __builder.CloseElement();
          __builder.AddMarkupContent(38, "\n                                ");
          __builder.OpenElement(39, "span");
          __builder.AddContent(40, change.Description);
          __builder.CloseElement();
          __builder.AddMarkupContent(41, "\n                            ");
          __builder.CloseElement();
          __builder.AddMarkupContent(42, "\n");
        }
        __builder.AddContent(43, "                    ");
        __builder.CloseElement();
        __builder.AddMarkupContent(44, "\n                ");
        __builder.CloseElement();
        __builder.AddMarkupContent(45, "\n");
      }
      __builder.AddContent(46, "        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(47, "\n\n        ");
      __builder.OpenElement(48, "div");
      __builder.AddAttribute(49, "class", "modal-bottom");
      __builder.AddMarkupContent(50, "\n            ");
      __builder.OpenElement(51, "h3");
      __builder.AddMarkupContent(52, "\n                ");
      __builder.OpenElement(53, "span");
      __builder.AddAttribute(54, "class", "hyperlink");
      __builder.AddAttribute<MouseEventArgs>(55, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Action) (() => WindowsUtilities.OpenURL("https://discord.gg/riftfn"))));
      __builder.AddContent(56, ChangelogModal.ChangelogDiscordAd);
      __builder.CloseElement();
      __builder.AddMarkupContent(57, "\n            ");
      __builder.CloseElement();
      __builder.AddMarkupContent(58, "\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(59, "\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(60, "\n");
      __builder.CloseElement();
    }
  }
}
