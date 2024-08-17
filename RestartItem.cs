using Quokka.ListItems;
using System;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace Plugin_PowerCommands {
  class RestartItem : ListItem {

    public RestartItem() {
      this.Name = "Restart";
      this.Description = "Closes all apps, turns off the PC and then turns it on again (This app is shutdown before the action is carried out)";
      this.Icon = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\PlugBoard\\Plugin_PowerCommands\\Plugin\\restart.png"));
    }

    public override void Execute() {
      var psi = new ProcessStartInfo("shutdown", "/g /t 3");
      psi.CreateNoWindow = true;
      psi.UseShellExecute = false;
      Process.Start(psi);
      Quokka.App.Current.Shutdown();
    }
  }

}
