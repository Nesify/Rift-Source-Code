// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.MainPage
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using Rift.Frontend.Models.Config;
using Rift.Frontend.Pages.FirstTimeSetup;
using Rift.Frontend.Pages.Static;
using Rift.Frontend.Services;
using Rift.Frontend.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;


#nullable enable
namespace Rift.Frontend
{
  public class MainPage : ComponentBase
  {
    public static 
    #nullable disable
    IJSRuntime JsRuntime { get; private set; }

    protected override async Task OnInitializedAsync()
    {
      MainPage.JsRuntime = this._jsRuntime;
      Logger.WriteLogQueue();
      await this._configService.LoadConfiguration();
      this._richPresenceService.Ping();
      if (App.Args.Length <= 1 || !(App.Args[0].ToLower() == "-launch"))
        return;
      await Task.Delay(500);
      Installation installation = this._configService.Configuration.Installations.FirstOrDefault<Installation>((Func<Installation, bool>) (x => x.Id == App.Args[1]));
      if (installation == null)
        return;
      await this._launcherService.StartGame(installation);
    }

    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenComponent<Stylesheets>(0);
      __builder.CloseComponent();
      __builder.AddMarkupContent(1, "\r\n");
      __builder.OpenComponent<Scripts>(2);
      __builder.CloseComponent();
      __builder.AddMarkupContent(3, "\r\n");
      __builder.OpenElement(4, "Console");
      __builder.CloseElement();
      __builder.AddMarkupContent(5, "\r\n\r\n");
      __builder.OpenElement(6, "div");
      __builder.AddAttribute(7, "class", "app");
      __builder.AddMarkupContent(8, "\r\n    ");
      __builder.OpenComponent<Watermark>(9);
      __builder.CloseComponent();
      __builder.AddMarkupContent(10, "\r\n");
      if (this._configService.RequireFirstTimeSetup)
      {
        __builder.AddContent(11, "        ");
        __builder.OpenComponent<FtsPage>(12);
        __builder.CloseComponent();
        __builder.AddMarkupContent(13, "\r\n");
      }
      else
      {
        __builder.AddContent(14, "        ");
        __builder.OpenComponent<Rift.Frontend.Pages.LauncherPage.LauncherPage>(15);
        __builder.CloseComponent();
        __builder.AddMarkupContent(16, "\r\n");
      }
      __builder.CloseElement();
    }

    [Inject]
    private RichPresenceService _richPresenceService { get; set; }

    [Inject]
    private LauncherService _launcherService { get; set; }

    [Inject]
    private UpdateService _updateService { get; set; }

    [Inject]
    private ConfigService _configService { get; set; }

    [Inject]
    private IJSRuntime _jsRuntime { get; set; }

    [Inject]
    private Hammer _hammer { get; set; }
  }
}
