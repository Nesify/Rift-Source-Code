// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.FirstTimeSetup.FtsBuild
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Rift.Frontend.Services;
using Rift.Frontend.Utilities;
using System;
using System.Threading.Tasks;


#nullable enable
namespace Rift.Frontend.Pages.FirstTimeSetup
{
  public class FtsBuild : ComponentBase
  {
    private 
    #nullable disable
    string _gamePath;
    private string _gameName;

    private void SetGamePath() => this._gamePath = WindowsUtilities.ChooseGamePath() ?? this._gamePath;

    private async Task Validate()
    {
      if (!await this._launcherService.RegisterGame(this._gameName, this._gamePath))
        return;
      string str1 = await this._jsRuntime.InvokeAsync<string>("rift.fts.steps.finalIn", (object[]) null);
      string str2 = await this._jsRuntime.InvokeAsync<string>("rift.fts.steps.finalOut", (object[]) null);
    }

    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "fts-page");
      __builder.AddAttribute(2, "id", "fts-build");
      __builder.AddAttribute(3, "style", "display: none");
      __builder.AddMarkupContent(4, "\r\n    ");
      __builder.AddMarkupContent(5, "<div class=\"text\">\r\n        <h1>Add a Fortnite install</h1>\r\n        <h3>Enter the path to the folder containing the Engine and FortniteGame folders.</h3>\r\n    </div>\r\n\r\n    ");
      __builder.OpenElement(6, "div");
      __builder.AddAttribute(7, "class", "content");
      __builder.AddMarkupContent(8, "\r\n        ");
      __builder.OpenElement(9, "div");
      __builder.AddAttribute(10, "class", "path-selector");
      __builder.AddMarkupContent(11, "\r\n            ");
      __builder.OpenElement(12, "div");
      __builder.AddAttribute(13, "class", "input-block");
      __builder.AddMarkupContent(14, "\r\n                ");
      __builder.OpenElement(15, "input");
      __builder.AddAttribute(16, "placeholder", "Game path");
      __builder.AddAttribute(17, "maxlength", "260");
      __builder.AddAttribute(18, "value", BindConverter.FormatValue(this._gamePath));
      __builder.AddAttribute<ChangeEventArgs>(19, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this._gamePath = __value), this._gamePath));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.AddMarkupContent(20, "\r\n                ");
      __builder.AddMarkupContent(21, "<span class=\"label\">Game path</span>\r\n            ");
      __builder.CloseElement();
      __builder.AddMarkupContent(22, "\r\n            ");
      __builder.OpenElement(23, "button");
      __builder.AddAttribute<MouseEventArgs>(24, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Action(this.SetGamePath)));
      __builder.AddContent(25, "...");
      __builder.CloseElement();
      __builder.AddMarkupContent(26, "\r\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(27, "\r\n        ");
      __builder.OpenElement(28, "div");
      __builder.AddAttribute(29, "class", "input-block");
      __builder.AddAttribute(30, "style", "width: 100%");
      __builder.AddMarkupContent(31, "\r\n            ");
      __builder.OpenElement(32, "input");
      __builder.AddAttribute(33, "placeholder", "Give your install a name");
      __builder.AddAttribute(34, "oninput", "rift.fts.utils.validateBtn(this, 'fts-build-next', 25, true)");
      __builder.AddAttribute(35, "maxlength", "25");
      __builder.AddAttribute(36, "value", BindConverter.FormatValue(this._gameName));
      __builder.AddAttribute<ChangeEventArgs>(37, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this._gameName = __value), this._gameName));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.AddMarkupContent(38, "\r\n            ");
      __builder.AddMarkupContent(39, "<span class=\"label\">Give your install a name</span>\r\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(40, "\r\n\r\n        ");
      __builder.OpenElement(41, "button");
      __builder.AddAttribute(42, "id", "fts-build-next");
      __builder.AddAttribute(43, "class", "disabled");
      __builder.AddAttribute<MouseEventArgs>(44, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.Validate)));
      __builder.AddContent(45, "Next");
      __builder.CloseElement();
      __builder.AddMarkupContent(46, "\r\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(47, "\r\n");
      __builder.CloseElement();
    }

    [Inject]
    private LauncherService _launcherService { get; set; }

    [Inject]
    private ConfigService _configService { get; set; }

    [Inject]
    private IJSRuntime _jsRuntime { get; set; }
  }
}
