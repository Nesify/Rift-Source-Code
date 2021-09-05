// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.App
// Assembly: Rift, Version=2.1.0.4, Culture=neutral, PublicKeyToken=null
// MVID: 0ACAFB20-2A21-412B-9705-20731E51C852
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Rift.dll

using Microsoft.Extensions.Hosting;
using Rift.Backend;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;


#nullable enable
namespace Rift.Frontend
{
  public class App : Application
  {
    public static 
    #nullable disable
    string[] Args { get; private set; }

    private void App_OnStartup(object sender, StartupEventArgs e)
    {
      App.Args = e.Args;
      MainWindow mainWindow = new MainWindow();
      mainWindow.Show();
      IHost apiHost = Program.CreateHostBuilder(e.Args).Build();
      mainWindow.Closing += (CancelEventHandler) (async (o, args) =>
      {
        await apiHost.StopAsync();
        Environment.Exit(0);
      });
      apiHost.RunAsync();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.9.0")]
    public void InitializeComponent() => this.Startup += new StartupEventHandler(this.App_OnStartup);

    [STAThread]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.9.0")]
    public static void Main()
    {
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}
