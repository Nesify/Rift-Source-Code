// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.LauncherPage.Tabs.SettingsTab
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Rift.Frontend.Services;
using System;
using System.Threading.Tasks;

namespace Rift.Frontend.Pages.LauncherPage.Tabs
{
  public class SettingsTab : ComponentBase
  {
    public static string PageHeader = "Edit Rift configuration";
    public static string PlayerUsernameField = "Username";
    public static string ArgumentsField = "Arguments";

    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "id", "settings-page");
      __builder.AddAttribute(2, "style", "display: none;");
      __builder.AddMarkupContent(3, "\n    ");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "section vertical");
      __builder.AddMarkupContent(6, "\n        ");
      __builder.OpenElement(7, "h1");
      __builder.AddContent(8, SettingsTab.PageHeader);
      __builder.CloseElement();
      __builder.AddMarkupContent(9, "\n\n        ");
      __builder.OpenElement(10, "div");
      __builder.AddAttribute(11, "class", "subsection");
      __builder.AddMarkupContent(12, "\n            ");
      __builder.OpenElement(13, "div");
      __builder.AddAttribute(14, "class", "input-block");
      __builder.AddMarkupContent(15, "\n                ");
      __builder.OpenElement(16, "input");
      __builder.AddAttribute(17, "placeholder", SettingsTab.PlayerUsernameField);
      __builder.AddAttribute<FocusEventArgs>(18, "onfocusout", EventCallback.Factory.Create<FocusEventArgs>((object) this, new Func<Task>(this._configService.SaveConfiguration)));
      __builder.AddAttribute(19, "value", BindConverter.FormatValue(this._configService.Configuration.DisplayName));
      __builder.AddAttribute<ChangeEventArgs>(20, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this._configService.Configuration.DisplayName = __value), this._configService.Configuration.DisplayName));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.AddMarkupContent(21, "\n                ");
      __builder.OpenElement(22, "span");
      __builder.AddAttribute(23, "class", "label");
      __builder.AddContent(24, SettingsTab.PlayerUsernameField);
      __builder.CloseElement();
      __builder.AddMarkupContent(25, "\n            ");
      __builder.CloseElement();
      __builder.AddMarkupContent(26, "\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(27, "\n        \n        ");
      __builder.OpenElement(28, "div");
      __builder.AddAttribute(29, "class", "subsection");
      __builder.AddMarkupContent(30, "\n            ");
      __builder.OpenElement(31, "div");
      __builder.AddAttribute(32, "class", "input-block");
      __builder.AddMarkupContent(33, "\n                ");
      __builder.OpenElement(34, "input");
      __builder.AddAttribute(35, "placeholder", SettingsTab.ArgumentsField);
      __builder.AddAttribute<FocusEventArgs>(36, "onfocusout", EventCallback.Factory.Create<FocusEventArgs>((object) this, new Func<Task>(this._configService.SaveConfiguration)));
      __builder.AddAttribute(37, "value", BindConverter.FormatValue(this._configService.Configuration.LaunchArgs));
      __builder.AddAttribute<ChangeEventArgs>(38, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this._configService.Configuration.LaunchArgs = __value), this._configService.Configuration.LaunchArgs));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.AddMarkupContent(39, "\n                ");
      __builder.OpenElement(40, "span");
      __builder.AddAttribute(41, "class", "label");
      __builder.AddContent(42, SettingsTab.ArgumentsField);
      __builder.CloseElement();
      __builder.AddMarkupContent(43, "\n            ");
      __builder.CloseElement();
      __builder.AddMarkupContent(44, "\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(45, "\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(46, "\n");
      __builder.CloseElement();
    }

    [Inject]
    private ConfigService _configService { get; set; }
  }
}
