using Quokka.ListItems;
using System;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace Plugin_PowerCommands {
  class ShutdownItem : ListItem {

    public ShutdownItem() {
      this.Name = "Shutdown";
      this.Description = "Closes all apps and turns off the PC (This app is shutdown before the action is carried out)";
      this.Icon = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\PlugBoard\\Plugin_PowerCommands\\Plugin\\shutdown.png"));
    }

    public override void Execute() {
      var psi = new ProcessStartInfo("shutdown", "/sg /t 3");
      psi.CreateNoWindow = true;
      psi.UseShellExecute = false;
      Process.Start(psi);
      Quokka.App.Current.Shutdown();
    }
  }

}
