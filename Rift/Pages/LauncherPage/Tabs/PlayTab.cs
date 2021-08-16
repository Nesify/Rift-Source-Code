// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.LauncherPage.Tabs.PlayTab
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Rift.Frontend.Models.Config;
using Rift.Frontend.Services;
using Rift.Frontend.Utilities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


#nullable enable
namespace Rift.Frontend.Pages.LauncherPage.Tabs
{
  public class PlayTab : ComponentBase
  {
    private 
    #nullable disable
    Installation _currentlyManaging;
    private string _newName;
    private string _newPath;
    public static string AddGameModalHeader = "Add a build";
    public static string AddGameModalDescription = "Not enough builds? Add another one.";
    public static string AddGameModalNameField = "Name";
    public static string AddGameModalGamePathField = "Game path";
    public static string AddGameModalConfirm = "Confirm";
    public static string RenameModalHeader = "Rename {0}";
    public static string RenameModalDescription = "Had a new name in mind?";
    public static string RenameModalNameField = "Name";
    public static string RenameModalSave = "Save";
    public static bool EnableBuildOrganizing = true;
    public static string ContextMenuPlayText = "Play";
    public static string ContextMenuRenameText = "Rename";
    public static string ContextMenuRemoveText = "Remove";
    public static string UpdateBackgroundUrl = "/img/chapter2.jpg";
    public static string UpdateHeaderText = "Rift {0}";
    public static string UpdateHeaderButton = "See what's new";
    public static bool UseRegexImagePaths = true;
    public static string BuildMoreDetailsText = "Right click for more options";
    public static string AddAnotherBuildText = "Add another build";
    public static string NoBuildKaomoji = "( ˃̣̣̥⌓˂̣̣̥)";
    public static string NoBuildSubtitle = "You don't have any builds!";
    public static string NoBuildButton = "Add a build";

    private async Task ShowContextMenuFor(Installation installation)
    {
      this._currentlyManaging = installation;
      string str = await this._jsRuntime.InvokeAsync<string>("rift.contextMenu.show", (object) (installation.Id + "-section"));
    }

    private async Task Play()
    {
      string str = await this._jsRuntime.InvokeAsync<string>("rift.contextMenu.hide", (object[]) null);
      await this._launcherService.StartGame(this._currentlyManaging);
    }

    private async Task ShowRenameWindow()
    {
      this._newName = this._currentlyManaging.Name;
      string str1 = await this._jsRuntime.InvokeAsync<string>("rift.contextMenu.hide", (object[]) null);
      string str2 = await this._jsRuntime.InvokeAsync<string>("rift.modalManager.showModal", (object) "rename");
    }

    private async Task ApplyRename()
    {
      string str = await this._jsRuntime.InvokeAsync<string>("rift.modalManager.hideModal", (object) "rename");
      this._currentlyManaging.Name = this._newName;
      await this._configService.SaveConfiguration();
    }

    private async Task Remove()
    {
      string str = await this._jsRuntime.InvokeAsync<string>("rift.contextMenu.hide", (object[]) null);
      this._configService.Configuration.Installations.Remove(this._currentlyManaging);
      await this._configService.SaveConfiguration();
    }

    private async Task AddNewBuild()
    {
      this._newName = "";
      this._newPath = "";
      string str = await this._jsRuntime.InvokeAsync<string>("rift.modalManager.showModal", (object) "new-game");
    }

    private async Task HideModalAndRegisterGame()
    {
      if (!await this._launcherService.RegisterGame(this._newName, this._newPath))
        return;
      string str = await this._jsRuntime.InvokeAsync<string>("rift.modalManager.hideModal", (object) "new-game");
    }

    private async Task Move(bool moveDown)
    {
      List<Installation> installs = this._configService.Configuration.Installations;
      int index = installs.IndexOf(this._currentlyManaging);
      if (!moveDown && index == 0)
        installs = (List<Installation>) null;
      else if (moveDown && index == installs.Count - 1)
      {
        installs = (List<Installation>) null;
      }
      else
      {
        string str = await this._jsRuntime.InvokeAsync<string>("rift.contextMenu.hide", (object[]) null);
        installs.Remove(this._currentlyManaging);
        index += moveDown ? 1 : -1;
        installs.Insert(index, this._currentlyManaging);
        await this._configService.SaveConfiguration();
        installs = (List<Installation>) null;
      }
    }

    public string GetImagePath(Installation installation)
    {
      if (!PlayTab.UseRegexImagePaths)
        return "/img/icons/fnch1.png";
      try
      {
        if (!Regex.IsMatch(installation.Id, "([\\d])+"))
          return "/img/icons/fnch1.png";
        int num = int.Parse(Regex.Matches(installation.Id, "([\\d])+")[0].Value);
        if (num < 4)
          return "/img/icons/fnch1old.png";
        return num > 11 ? string.Format("/img/icons/fnch2s{0}.png", (object) (num % 10)) : "/img/icons/fnch1.png";
      }
      catch
      {
        return "/img/icons/fnch1.png";
      }
    }

    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      __builder.AddAttribute(1, "class", "modal minimized");
      __builder.AddAttribute(2, "id", "new-game-modal");
      __builder.AddMarkupContent(3, "\r\n    ");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "modal-window");
      __builder.AddAttribute(6, "style", "width: 490px");
      __builder.AddMarkupContent(7, "\r\n        ");
      __builder.AddMarkupContent(8, "<div class=\"close-button\" onclick=\"rift.modalManager.hideModal('new-game')\">\r\n            <i class=\"fas fa-times\"></i>\r\n        </div>\r\n        ");
      __builder.OpenElement(9, "div");
      __builder.AddAttribute(10, "class", "modal-header");
      __builder.AddAttribute(11, "style", "padding-bottom: 15px");
      __builder.AddMarkupContent(12, "\r\n            ");
      __builder.OpenElement(13, "h1");
      __builder.AddAttribute(14, "class", "modal-title");
      __builder.AddContent(15, PlayTab.AddGameModalHeader);
      __builder.CloseElement();
      __builder.AddMarkupContent(16, "\r\n            ");
      __builder.OpenElement(17, "p");
      __builder.AddAttribute(18, "class", "modal-desc");
      __builder.AddContent(19, PlayTab.AddGameModalDescription);
      __builder.CloseElement();
      __builder.AddMarkupContent(20, "\r\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(21, "\r\n\r\n        ");
      __builder.OpenElement(22, "div");
      __builder.AddAttribute(23, "class", "input-block");
      __builder.AddAttribute(24, "style", "width: 100%; margin-bottom: 5px");
      __builder.AddMarkupContent(25, "\r\n            ");
      __builder.OpenElement(26, "input");
      __builder.AddAttribute(27, "placeholder", PlayTab.AddGameModalNameField);
      __builder.AddAttribute(28, "maxlength", "25");
      __builder.AddAttribute(29, "value", BindConverter.FormatValue(this._newName));
      __builder.AddAttribute<ChangeEventArgs>(30, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this._newName = __value), this._newName));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.AddMarkupContent(31, "\r\n            ");
      __builder.OpenElement(32, "span");
      __builder.AddAttribute(33, "class", "label");
      __builder.AddContent(34, PlayTab.AddGameModalNameField);
      __builder.CloseElement();
      __builder.AddMarkupContent(35, "\r\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(36, "\r\n        ");
      __builder.OpenElement(37, "div");
      __builder.AddAttribute(38, "class", "path-selector");
      __builder.AddAttribute(39, "style", "width: 100%; margin-bottom: 10px");
      __builder.AddMarkupContent(40, "\r\n            ");
      __builder.OpenElement(41, "div");
      __builder.AddAttribute(42, "class", "input-block");
      __builder.AddAttribute(43, "style", "width: 100%");
      __builder.AddMarkupContent(44, "\r\n                ");
      __builder.OpenElement(45, "input");
      __builder.AddAttribute(46, "placeholder", PlayTab.AddGameModalGamePathField);
      __builder.AddAttribute(47, "maxlength", "260");
      __builder.AddAttribute(48, "value", BindConverter.FormatValue(this._newPath));
      __builder.AddAttribute<ChangeEventArgs>(49, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this._newPath = __value), this._newPath));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.AddMarkupContent(50, "\r\n                ");
      __builder.OpenElement(51, "span");
      __builder.AddAttribute(52, "class", "label");
      __builder.AddContent(53, PlayTab.AddGameModalGamePathField);
      __builder.CloseElement();
      __builder.AddMarkupContent(54, "\r\n            ");
      __builder.CloseElement();
      __builder.AddMarkupContent(55, "\r\n            ");
      __builder.OpenElement(56, "button");
      __builder.AddAttribute<MouseEventArgs>(57, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Action) (() => this._newPath = WindowsUtilities.ChooseGamePath() ?? this._newPath)));
      __builder.AddContent(58, "...");
      __builder.CloseElement();
      __builder.AddMarkupContent(59, "\r\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(60, "\r\n        ");
      __builder.OpenElement(61, "button");
      __builder.AddAttribute<MouseEventArgs>(62, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.HideModalAndRegisterGame)));
      __builder.AddContent(63, PlayTab.AddGameModalConfirm);
      __builder.CloseElement();
      __builder.AddMarkupContent(64, "\r\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(65, "\r\n");
      __builder.CloseElement();
      __builder.AddMarkupContent(66, "\r\n\r\n\r\n");
      if (this._currentlyManaging != null)
      {
        __builder.AddContent(67, "    ");
        __builder.OpenElement(68, "div");
        __builder.AddAttribute(69, "class", "modal minimized");
        __builder.AddAttribute(70, "id", "rename-modal");
        __builder.AddMarkupContent(71, "\r\n        ");
        __builder.OpenElement(72, "div");
        __builder.AddAttribute(73, "class", "modal-window");
        __builder.AddAttribute(74, "style", "width: 490px");
        __builder.AddMarkupContent(75, "\r\n            ");
        __builder.AddMarkupContent(76, "<div class=\"close-button\" onclick=\"rift.modalManager.hideModal('rename')\">\r\n                <i class=\"fas fa-times\"></i>\r\n            </div>\r\n            ");
        __builder.OpenElement(77, "div");
        __builder.AddAttribute(78, "class", "modal-header");
        __builder.AddAttribute(79, "style", "padding-bottom: 15px");
        __builder.AddMarkupContent(80, "\r\n                ");
        __builder.OpenElement(81, "h1");
        __builder.AddAttribute(82, "class", "modal-title");
        __builder.AddContent(83, string.Format(PlayTab.RenameModalHeader, (object) this._currentlyManaging.Name));
        __builder.CloseElement();
        __builder.AddMarkupContent(84, "\r\n                ");
        __builder.OpenElement(85, "p");
        __builder.AddAttribute(86, "class", "modal-desc");
        __builder.AddContent(87, PlayTab.RenameModalDescription);
        __builder.CloseElement();
        __builder.AddMarkupContent(88, "\r\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(89, "\r\n\r\n            ");
        __builder.OpenElement(90, "div");
        __builder.AddAttribute(91, "class", "input-block");
        __builder.AddAttribute(92, "style", "width: 100%; margin-bottom: 5px");
        __builder.AddMarkupContent(93, "\r\n                ");
        __builder.OpenElement(94, "input");
        __builder.AddAttribute(95, "placeholder", PlayTab.RenameModalNameField);
        __builder.AddAttribute(96, "maxlength", "25");
        __builder.AddAttribute(97, "value", BindConverter.FormatValue(this._newName));
        __builder.AddAttribute<ChangeEventArgs>(98, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this._newName = __value), this._newName));
        __builder.SetUpdatesAttributeName("value");
        __builder.CloseElement();
        __builder.AddMarkupContent(99, "\r\n                ");
        __builder.OpenElement(100, "span");
        __builder.AddAttribute(101, "class", "label");
        __builder.AddContent(102, PlayTab.RenameModalNameField);
        __builder.CloseElement();
        __builder.AddMarkupContent(103, "\r\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(104, "\r\n            ");
        __builder.OpenElement(105, "button");
        __builder.AddAttribute<MouseEventArgs>(106, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.ApplyRename)));
        __builder.AddContent(107, PlayTab.RenameModalSave);
        __builder.CloseElement();
        __builder.AddMarkupContent(108, "\r\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(109, "\r\n    ");
        __builder.CloseElement();
        __builder.AddMarkupContent(110, "\r\n");
      }
      __builder.AddMarkupContent(111, "\r\n\r\n");
      __builder.OpenElement(112, "div");
      __builder.AddAttribute(113, "class", "context-menu-container");
      __builder.AddAttribute(114, "style", "display: none");
      __builder.AddMarkupContent(115, "\r\n    ");
      __builder.OpenElement(116, "div");
      __builder.AddAttribute(117, "class", "context-menu");
      __builder.AddMarkupContent(118, "\r\n        ");
      __builder.OpenElement(119, "button");
      __builder.AddAttribute<MouseEventArgs>(120, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.Play)));
      __builder.AddMarkupContent(121, "\r\n            <i class=\"fas fa-play\"></i>\r\n            ");
      __builder.AddContent(122, PlayTab.ContextMenuPlayText);
      __builder.AddMarkupContent(123, "\r\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(124, "\r\n        ");
      __builder.OpenElement(125, "button");
      __builder.AddAttribute<MouseEventArgs>(126, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.ShowRenameWindow)));
      __builder.AddMarkupContent((int) sbyte.MaxValue, "\r\n            <i class=\"fas fa-edit\"></i>\r\n            ");
      __builder.AddContent(128, PlayTab.ContextMenuRenameText);
      __builder.AddMarkupContent(129, "\r\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(130, "\r\n        <hr>\r\n");
      if (PlayTab.EnableBuildOrganizing)
      {
        __builder.AddContent(131, "            ");
        __builder.OpenElement(132, "div");
        __builder.AddAttribute(133, "class", "context-horizontal");
        __builder.AddMarkupContent(134, "\r\n");
        if (this._currentlyManaging != null)
        {
          int num = this._configService.Configuration.Installations.IndexOf(this._currentlyManaging);
          string str1 = num > 0 ? "" : "disabled";
          string str2 = num < this._configService.Configuration.Installations.Count - 1 ? "" : "disabled";
          __builder.AddContent(135, "                    ");
          __builder.OpenElement(136, "button");
          __builder.AddAttribute<MouseEventArgs>(137, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.Move(false))));
          __builder.AddAttribute(138, "class", str1);
          __builder.AddMarkupContent(139, "\r\n                        <i class=\"fas fa-arrow-up\"></i>\r\n                    ");
          __builder.CloseElement();
          __builder.AddMarkupContent(140, "\r\n                    ");
          __builder.OpenElement(141, "button");
          __builder.AddAttribute<MouseEventArgs>(142, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.Move(true))));
          __builder.AddAttribute(143, "class", str2);
          __builder.AddMarkupContent(144, "\r\n                        <i class=\"fas fa-arrow-down\"></i>\r\n                    ");
          __builder.CloseElement();
          __builder.AddMarkupContent(145, "\r\n");
        }
        __builder.AddContent(146, "            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(147, "\r\n            <hr>\r\n");
      }
      __builder.AddContent(148, "        ");
      __builder.OpenElement(149, "button");
      __builder.AddAttribute(150, "class", "bad");
      __builder.AddAttribute<MouseEventArgs>(151, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.Remove)));
      __builder.AddMarkupContent(152, "\r\n            <i class=\"fas fa-trash\"></i>\r\n            ");
      __builder.AddContent(153, PlayTab.ContextMenuRemoveText);
      __builder.AddMarkupContent(154, "\r\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(155, "\r\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(156, "\r\n");
      __builder.CloseElement();
      __builder.AddMarkupContent(157, "\r\n\r\n");
      __builder.OpenElement(158, "div");
      __builder.AddAttribute(159, "id", "play-page");
      __builder.AddAttribute(160, "style", "display: none;");
      __builder.AddMarkupContent(161, "\r\n    ");
      __builder.OpenElement(162, "div");
      __builder.AddAttribute(163, "class", "header");
      __builder.AddAttribute(164, "style", "transform: translateY(0px);");
      __builder.AddMarkupContent(165, "\r\n        ");
      __builder.OpenElement(166, "img");
      __builder.AddAttribute(167, "src", PlayTab.UpdateBackgroundUrl);
      __builder.AddAttribute(168, "alt", "Banner");
      __builder.CloseElement();
      __builder.AddMarkupContent(169, "\r\n        <div class=\"fade\"></div>\r\n        ");
      __builder.OpenElement(170, "h1");
      __builder.AddContent(171, string.Format(PlayTab.UpdateHeaderText, (object) Strings.TRIMMED_VERSION_STRING));
      __builder.CloseElement();
      __builder.AddMarkupContent(172, "\r\n        ");
      __builder.OpenElement(173, "h3");
      __builder.AddContent(174, Constants.CHANGELOG.Description);
      __builder.CloseElement();
      __builder.AddMarkupContent(175, "\r\n        ");
      __builder.OpenElement(176, "button");
      __builder.AddAttribute(177, "onclick", "rift.modalManager.showModal('changelog')");
      __builder.AddContent(178, PlayTab.UpdateHeaderButton);
      __builder.CloseElement();
      __builder.AddMarkupContent(179, "\r\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(180, "\r\n\r\n");
      foreach (Installation installation1 in this._configService.Configuration.Installations)
      {
        Installation installation = installation1;
        __builder.AddContent(181, "        ");
        __builder.OpenElement(182, "div");
        __builder.AddAttribute(183, "id", installation.Id + "-section");
        __builder.AddAttribute(184, "class", "section hoverable");
        __builder.AddAttribute<MouseEventArgs>(185, "oncontextmenu", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.ShowContextMenuFor(installation))));
        __builder.AddAttribute<MouseEventArgs>(186, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this._launcherService.StartGame(installation))));
        __builder.AddMarkupContent(187, "\r\n            ");
        __builder.OpenElement(188, "img");
        __builder.AddAttribute(189, "src", this.GetImagePath(installation));
        __builder.AddAttribute(190, "alt", "Icon");
        __builder.CloseElement();
        __builder.AddMarkupContent(191, "\r\n            ");
        __builder.OpenElement(192, "div");
        __builder.AddAttribute(193, "class", "name");
        __builder.AddMarkupContent(194, "\r\n                ");
        __builder.OpenElement(195, "h1");
        __builder.AddContent(196, installation.Name);
        __builder.CloseElement();
        __builder.AddMarkupContent(197, "\r\n                ");
        __builder.OpenElement(198, "h3");
        __builder.AddContent(199, installation.Path);
        __builder.CloseElement();
        __builder.AddMarkupContent(200, "\r\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(201, "\r\n            ");
        __builder.OpenElement(202, "div");
        __builder.AddAttribute(203, "class", "right");
        __builder.AddMarkupContent(204, "\r\n                ");
        __builder.OpenElement(205, "h3");
        __builder.AddContent(206, PlayTab.BuildMoreDetailsText);
        __builder.CloseElement();
        __builder.AddMarkupContent(207, "\r\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(208, "\r\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(209, "\r\n");
      }
      if (this._configService.Configuration.Installations.Count == 0)
      {
        __builder.AddContent(210, "        ");
        __builder.OpenElement(211, "div");
        __builder.AddAttribute(212, "class", "tab-message");
        __builder.AddMarkupContent(213, "\r\n            ");
        __builder.OpenElement(214, "div");
        __builder.AddAttribute(215, "class", "text");
        __builder.AddMarkupContent(216, "\r\n                ");
        __builder.OpenElement(217, "h1");
        __builder.AddContent(218, PlayTab.NoBuildKaomoji);
        __builder.CloseElement();
        __builder.AddMarkupContent(219, "\r\n                ");
        __builder.OpenElement(220, "h3");
        __builder.AddContent(221, PlayTab.NoBuildSubtitle);
        __builder.CloseElement();
        __builder.AddMarkupContent(222, "\r\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(223, "\r\n            ");
        __builder.OpenElement(224, "div");
        __builder.AddAttribute(225, "class", "controls");
        __builder.AddMarkupContent(226, "\r\n                ");
        __builder.OpenElement(227, "button");
        __builder.AddAttribute<MouseEventArgs>(228, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.AddNewBuild)));
        __builder.AddMarkupContent(229, "\r\n                    <i class=\"fas fa-plus\" style=\"padding-right: 5px\"></i> ");
        __builder.AddContent(230, PlayTab.NoBuildButton);
        __builder.AddMarkupContent(231, "\r\n                ");
        __builder.CloseElement();
        __builder.AddMarkupContent(232, "\r\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(233, "\r\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(234, "\r\n");
      }
      else
      {
        __builder.AddContent(235, "        ");
        __builder.OpenElement(236, "span");
        __builder.AddAttribute(237, "class", "tab-bottom");
        __builder.AddAttribute<MouseEventArgs>(238, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.AddNewBuild)));
        __builder.AddContent(239, PlayTab.AddAnotherBuildText);
        __builder.CloseElement();
        __builder.AddMarkupContent(240, "\r\n");
      }
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
