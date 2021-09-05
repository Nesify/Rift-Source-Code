// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Pages.LauncherPage.Tabs.PlayTab
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Rift.Frontend.Models.Config;
using Rift.Frontend.Services;
using Rift.Frontend.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public static bool RiftMultiplayerEvent = false;
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

    private async Task StartGameWithLuna() => await this._launcherService.StartGameWithLuna(this._configService.Configuration.Installations.FirstOrDefault<Installation>((Func<Installation, bool>) (x => x.Name.Contains("6.10"))));

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
      __builder.AddMarkupContent(3, "\n    ");
      __builder.OpenElement(4, "div");
      __builder.AddAttribute(5, "class", "modal-window");
      __builder.AddAttribute(6, "style", "width: 490px");
      __builder.AddMarkupContent(7, "\n        ");
      __builder.AddMarkupContent(8, "<div class=\"close-button\" onclick=\"rift.modalManager.hideModal('new-game')\">\n            <i class=\"fas fa-times\"></i>\n        </div>\n        ");
      __builder.OpenElement(9, "div");
      __builder.AddAttribute(10, "class", "modal-header");
      __builder.AddAttribute(11, "style", "padding-bottom: 15px");
      __builder.AddMarkupContent(12, "\n            ");
      __builder.OpenElement(13, "h1");
      __builder.AddAttribute(14, "class", "modal-title");
      __builder.AddContent(15, PlayTab.AddGameModalHeader);
      __builder.CloseElement();
      __builder.AddMarkupContent(16, "\n            ");
      __builder.OpenElement(17, "p");
      __builder.AddAttribute(18, "class", "modal-desc");
      __builder.AddContent(19, PlayTab.AddGameModalDescription);
      __builder.CloseElement();
      __builder.AddMarkupContent(20, "\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(21, "\n\n        ");
      __builder.OpenElement(22, "div");
      __builder.AddAttribute(23, "class", "input-block");
      __builder.AddAttribute(24, "style", "width: 100%; margin-bottom: 5px");
      __builder.AddMarkupContent(25, "\n            ");
      __builder.OpenElement(26, "input");
      __builder.AddAttribute(27, "placeholder", PlayTab.AddGameModalNameField);
      __builder.AddAttribute(28, "maxlength", "25");
      __builder.AddAttribute(29, "value", BindConverter.FormatValue(this._newName));
      __builder.AddAttribute<ChangeEventArgs>(30, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this._newName = __value), this._newName));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.AddMarkupContent(31, "\n            ");
      __builder.OpenElement(32, "span");
      __builder.AddAttribute(33, "class", "label");
      __builder.AddContent(34, PlayTab.AddGameModalNameField);
      __builder.CloseElement();
      __builder.AddMarkupContent(35, "\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(36, "\n        ");
      __builder.OpenElement(37, "div");
      __builder.AddAttribute(38, "class", "path-selector");
      __builder.AddAttribute(39, "style", "width: 100%; margin-bottom: 10px");
      __builder.AddMarkupContent(40, "\n            ");
      __builder.OpenElement(41, "div");
      __builder.AddAttribute(42, "class", "input-block");
      __builder.AddAttribute(43, "style", "width: 100%");
      __builder.AddMarkupContent(44, "\n                ");
      __builder.OpenElement(45, "input");
      __builder.AddAttribute(46, "placeholder", PlayTab.AddGameModalGamePathField);
      __builder.AddAttribute(47, "maxlength", "260");
      __builder.AddAttribute(48, "value", BindConverter.FormatValue(this._newPath));
      __builder.AddAttribute<ChangeEventArgs>(49, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this._newPath = __value), this._newPath));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.AddMarkupContent(50, "\n                ");
      __builder.OpenElement(51, "span");
      __builder.AddAttribute(52, "class", "label");
      __builder.AddContent(53, PlayTab.AddGameModalGamePathField);
      __builder.CloseElement();
      __builder.AddMarkupContent(54, "\n            ");
      __builder.CloseElement();
      __builder.AddMarkupContent(55, "\n            ");
      __builder.OpenElement(56, "button");
      __builder.AddAttribute<MouseEventArgs>(57, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Action) (() => this._newPath = WindowsUtilities.ChooseGamePath() ?? this._newPath)));
      __builder.AddContent(58, "...");
      __builder.CloseElement();
      __builder.AddMarkupContent(59, "\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(60, "\n        ");
      __builder.OpenElement(61, "button");
      __builder.AddAttribute<MouseEventArgs>(62, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.HideModalAndRegisterGame)));
      __builder.AddContent(63, PlayTab.AddGameModalConfirm);
      __builder.CloseElement();
      __builder.AddMarkupContent(64, "\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(65, "\n");
      __builder.CloseElement();
      __builder.AddMarkupContent(66, "\n\n\n");
      if (this._currentlyManaging != null)
      {
        __builder.AddContent(67, "    ");
        __builder.OpenElement(68, "div");
        __builder.AddAttribute(69, "class", "modal minimized");
        __builder.AddAttribute(70, "id", "rename-modal");
        __builder.AddMarkupContent(71, "\n        ");
        __builder.OpenElement(72, "div");
        __builder.AddAttribute(73, "class", "modal-window");
        __builder.AddAttribute(74, "style", "width: 490px");
        __builder.AddMarkupContent(75, "\n            ");
        __builder.AddMarkupContent(76, "<div class=\"close-button\" onclick=\"rift.modalManager.hideModal('rename')\">\n                <i class=\"fas fa-times\"></i>\n            </div>\n            ");
        __builder.OpenElement(77, "div");
        __builder.AddAttribute(78, "class", "modal-header");
        __builder.AddAttribute(79, "style", "padding-bottom: 15px");
        __builder.AddMarkupContent(80, "\n                ");
        __builder.OpenElement(81, "h1");
        __builder.AddAttribute(82, "class", "modal-title");
        __builder.AddContent(83, string.Format(PlayTab.RenameModalHeader, (object) this._currentlyManaging.Name));
        __builder.CloseElement();
        __builder.AddMarkupContent(84, "\n                ");
        __builder.OpenElement(85, "p");
        __builder.AddAttribute(86, "class", "modal-desc");
        __builder.AddContent(87, PlayTab.RenameModalDescription);
        __builder.CloseElement();
        __builder.AddMarkupContent(88, "\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(89, "\n\n            ");
        __builder.OpenElement(90, "div");
        __builder.AddAttribute(91, "class", "input-block");
        __builder.AddAttribute(92, "style", "width: 100%; margin-bottom: 5px");
        __builder.AddMarkupContent(93, "\n                ");
        __builder.OpenElement(94, "input");
        __builder.AddAttribute(95, "placeholder", PlayTab.RenameModalNameField);
        __builder.AddAttribute(96, "maxlength", "25");
        __builder.AddAttribute(97, "value", BindConverter.FormatValue(this._newName));
        __builder.AddAttribute<ChangeEventArgs>(98, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this._newName = __value), this._newName));
        __builder.SetUpdatesAttributeName("value");
        __builder.CloseElement();
        __builder.AddMarkupContent(99, "\n                ");
        __builder.OpenElement(100, "span");
        __builder.AddAttribute(101, "class", "label");
        __builder.AddContent(102, PlayTab.RenameModalNameField);
        __builder.CloseElement();
        __builder.AddMarkupContent(103, "\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(104, "\n            ");
        __builder.OpenElement(105, "button");
        __builder.AddAttribute<MouseEventArgs>(106, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.ApplyRename)));
        __builder.AddContent(107, PlayTab.RenameModalSave);
        __builder.CloseElement();
        __builder.AddMarkupContent(108, "\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(109, "\n    ");
        __builder.CloseElement();
        __builder.AddMarkupContent(110, "\n");
      }
      __builder.AddMarkupContent(111, "\n\n");
      __builder.OpenElement(112, "div");
      __builder.AddAttribute(113, "class", "context-menu-container");
      __builder.AddAttribute(114, "style", "display: none");
      __builder.AddMarkupContent(115, "\n    ");
      __builder.OpenElement(116, "div");
      __builder.AddAttribute(117, "class", "context-menu");
      __builder.AddMarkupContent(118, "\n        ");
      __builder.OpenElement(119, "button");
      __builder.AddAttribute<MouseEventArgs>(120, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.Play)));
      __builder.AddMarkupContent(121, "\n            <i class=\"fas fa-play\"></i>\n            ");
      __builder.AddContent(122, PlayTab.ContextMenuPlayText);
      __builder.AddMarkupContent(123, "\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(124, "\n        ");
      __builder.OpenElement(125, "button");
      __builder.AddAttribute<MouseEventArgs>(126, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.ShowRenameWindow)));
      __builder.AddMarkupContent((int) sbyte.MaxValue, "\n            <i class=\"fas fa-edit\"></i>\n            ");
      __builder.AddContent(128, PlayTab.ContextMenuRenameText);
      __builder.AddMarkupContent(129, "\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(130, "\n        <hr>\n");
      if (PlayTab.EnableBuildOrganizing)
      {
        __builder.AddContent(131, "            ");
        __builder.OpenElement(132, "div");
        __builder.AddAttribute(133, "class", "context-horizontal");
        __builder.AddMarkupContent(134, "\n");
        if (this._currentlyManaging != null)
        {
          int num = this._configService.Configuration.Installations.IndexOf(this._currentlyManaging);
          string str1 = num > 0 ? "" : "disabled";
          string str2 = num < this._configService.Configuration.Installations.Count - 1 ? "" : "disabled";
          __builder.AddContent(135, "                    ");
          __builder.OpenElement(136, "button");
          __builder.AddAttribute<MouseEventArgs>(137, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.Move(false))));
          __builder.AddAttribute(138, "class", str1);
          __builder.AddMarkupContent(139, "\n                        <i class=\"fas fa-arrow-up\"></i>\n                    ");
          __builder.CloseElement();
          __builder.AddMarkupContent(140, "\n                    ");
          __builder.OpenElement(141, "button");
          __builder.AddAttribute<MouseEventArgs>(142, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.Move(true))));
          __builder.AddAttribute(143, "class", str2);
          __builder.AddMarkupContent(144, "\n                        <i class=\"fas fa-arrow-down\"></i>\n                    ");
          __builder.CloseElement();
          __builder.AddMarkupContent(145, "\n");
        }
        __builder.AddContent(146, "            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(147, "\n            <hr>\n");
      }
      __builder.AddContent(148, "        ");
      __builder.OpenElement(149, "button");
      __builder.AddAttribute(150, "class", "bad");
      __builder.AddAttribute<MouseEventArgs>(151, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.Remove)));
      __builder.AddMarkupContent(152, "\n            <i class=\"fas fa-trash\"></i>\n            ");
      __builder.AddContent(153, PlayTab.ContextMenuRemoveText);
      __builder.AddMarkupContent(154, "\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(155, "\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(156, "\n");
      __builder.CloseElement();
      __builder.AddMarkupContent(157, "\n\n");
      __builder.OpenElement(158, "div");
      __builder.AddAttribute(159, "id", "play-page");
      __builder.AddAttribute(160, "style", "display: none;");
      __builder.AddMarkupContent(161, "\n");
      if (PlayTab.RiftMultiplayerEvent)
      {
        __builder.AddContent(162, "        ");
        __builder.OpenElement(163, "div");
        __builder.AddAttribute(164, "class", "header");
        __builder.AddAttribute(165, "style", "transform: translateY(0px);");
        __builder.AddMarkupContent(166, "\n                <img src=\"/img/riftmulti.jpg\" alt=\"Banner\">\n                <div class=\"fade\"></div>\n                ");
        __builder.AddMarkupContent(167, "<h1>Rift Multiplayer</h1>\n");
        if (this._configService.Configuration.Installations.Count<Installation>((Func<Installation, bool>) (x => x.Name.Contains("6.10"))) > 0)
        {
          __builder.AddContent(168, "                    ");
          __builder.AddMarkupContent(169, "<h3>Rift is doing a one-time multiplayer event on Fortnite 6.10. Jump in now!</h3>\n                    ");
          __builder.OpenElement(170, "button");
          __builder.AddAttribute<MouseEventArgs>(171, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.StartGameWithLuna)));
          __builder.AddContent(172, "Play now");
          __builder.CloseElement();
          __builder.AddMarkupContent(173, "\n");
        }
        else
        {
          __builder.AddContent(174, "                    ");
          __builder.AddMarkupContent(175, "<h3 style=\"text-align: center; line-height: 1.3;\">Rift is doing a one-time multiplayer event on Fortnite 6.10. <p style=\"color: #ff7373;\">You don't appear to have 6.10. If you have it installed, name your install \"Fortnite 6.10\".</p></h3>\n");
        }
        __builder.AddContent(176, "        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(177, "\n");
      }
      else
      {
        __builder.AddContent(178, "        ");
        __builder.OpenElement(179, "div");
        __builder.AddAttribute(180, "class", "header");
        __builder.AddAttribute(181, "style", "transform: translateY(0px);");
        __builder.AddMarkupContent(182, "\n            ");
        __builder.OpenElement(183, "img");
        __builder.AddAttribute(184, "src", PlayTab.UpdateBackgroundUrl);
        __builder.AddAttribute(185, "alt", "Banner");
        __builder.CloseElement();
        __builder.AddMarkupContent(186, "\n            <div class=\"fade\"></div>\n            ");
        __builder.OpenElement(187, "h1");
        __builder.AddContent(188, string.Format(PlayTab.UpdateHeaderText, (object) Strings.TRIMMED_VERSION_STRING));
        __builder.CloseElement();
        __builder.AddMarkupContent(189, "\n            ");
        __builder.OpenElement(190, "h3");
        __builder.AddContent(191, Constants.CHANGELOG.Description);
        __builder.CloseElement();
        __builder.AddMarkupContent(192, "\n            ");
        __builder.OpenElement(193, "button");
        __builder.AddAttribute(194, "onclick", "rift.modalManager.showModal('changelog')");
        __builder.AddContent(195, PlayTab.UpdateHeaderButton);
        __builder.CloseElement();
        __builder.AddMarkupContent(196, "\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(197, "\n");
      }
      __builder.AddMarkupContent(198, "\n");
      foreach (Installation installation1 in this._configService.Configuration.Installations)
      {
        Installation installation = installation1;
        __builder.AddContent(199, "        ");
        __builder.OpenElement(200, "div");
        __builder.AddAttribute(201, "id", installation.Id + "-section");
        __builder.AddAttribute(202, "class", "section hoverable");
        __builder.AddAttribute<MouseEventArgs>(203, "oncontextmenu", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.ShowContextMenuFor(installation))));
        __builder.AddAttribute<MouseEventArgs>(204, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this._launcherService.StartGame(installation))));
        __builder.AddMarkupContent(205, "\n            ");
        __builder.OpenElement(206, "img");
        __builder.AddAttribute(207, "src", this.GetImagePath(installation));
        __builder.AddAttribute(208, "alt", "Icon");
        __builder.CloseElement();
        __builder.AddMarkupContent(209, "\n            ");
        __builder.OpenElement(210, "div");
        __builder.AddAttribute(211, "class", "name");
        __builder.AddMarkupContent(212, "\n                ");
        __builder.OpenElement(213, "h1");
        __builder.AddContent(214, installation.Name);
        __builder.CloseElement();
        __builder.AddMarkupContent(215, "\n                ");
        __builder.OpenElement(216, "h3");
        __builder.AddContent(217, installation.Path);
        __builder.CloseElement();
        __builder.AddMarkupContent(218, "\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(219, "\n            ");
        __builder.OpenElement(220, "div");
        __builder.AddAttribute(221, "class", "right");
        __builder.AddMarkupContent(222, "\n                ");
        __builder.OpenElement(223, "h3");
        __builder.AddContent(224, PlayTab.BuildMoreDetailsText);
        __builder.CloseElement();
        __builder.AddMarkupContent(225, "\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(226, "\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(227, "\n");
      }
      if (this._configService.Configuration.Installations.Count == 0)
      {
        __builder.AddContent(228, "        ");
        __builder.OpenElement(229, "div");
        __builder.AddAttribute(230, "class", "tab-message");
        __builder.AddMarkupContent(231, "\n            ");
        __builder.OpenElement(232, "div");
        __builder.AddAttribute(233, "class", "text");
        __builder.AddMarkupContent(234, "\n                ");
        __builder.OpenElement(235, "h1");
        __builder.AddContent(236, PlayTab.NoBuildKaomoji);
        __builder.CloseElement();
        __builder.AddMarkupContent(237, "\n                ");
        __builder.OpenElement(238, "h3");
        __builder.AddContent(239, PlayTab.NoBuildSubtitle);
        __builder.CloseElement();
        __builder.AddMarkupContent(240, "\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(241, "\n            ");
        __builder.OpenElement(242, "div");
        __builder.AddAttribute(243, "class", "controls");
        __builder.AddMarkupContent(244, "\n                ");
        __builder.OpenElement(245, "button");
        __builder.AddAttribute<MouseEventArgs>(246, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.AddNewBuild)));
        __builder.AddMarkupContent(247, "\n                    <i class=\"fas fa-plus\" style=\"padding-right: 5px\"></i> ");
        __builder.AddContent(248, PlayTab.NoBuildButton);
        __builder.AddMarkupContent(249, "\n                ");
        __builder.CloseElement();
        __builder.AddMarkupContent(250, "\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(251, "\n        ");
        __builder.CloseElement();
        __builder.AddMarkupContent(252, "\n");
      }
      else
      {
        __builder.AddContent(253, "        ");
        __builder.OpenElement(254, "span");
        __builder.AddAttribute((int) byte.MaxValue, "class", "tab-bottom");
        __builder.AddAttribute<MouseEventArgs>(256, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, new Func<Task>(this.AddNewBuild)));
        __builder.AddContent(257, PlayTab.AddAnotherBuildText);
        __builder.CloseElement();
        __builder.AddMarkupContent(258, "\n");
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
