using Quokka;
using Quokka.ListItems;
using Quokka.PluginArch;
using System;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Plugin_PowerCommands {
  class SleepItem : ListItem {

    public SleepItem() {
      Name = "Sleep";
      Description = "The PC stays on but uses low power. Apps stay open so you can come back to where you left off";
      UiDispatcher.BeginInvoke(() => {
        Icon = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\PlugBoard\\Plugin_PowerCommands\\Plugin\\sleep.png"));
      });
    }

    public override void Execute() {
      App.Current.MainWindow.Close();
      Application.SetSuspendState(PowerState.Suspend, true, true);
    }
  }

}
