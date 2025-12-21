using Quokka;
using Quokka.ListItems;
using Quokka.PluginArch;
using System.Windows.Forms;

namespace PluginPowerCommands
{
  class SleepItem : ListItem
  {

    public SleepItem()
    {
      Name = "Sleep";
      Description = "The PC stays on but uses low power. Apps stay open so you can come back to where you left off";
      Icon = IconCache.GetOrAdd(
        Environment.CurrentDirectory + "\\PlugBoard\\PluginPowerCommands\\Plugin\\sleep.png"
      );
    }

    public override void Execute()
    {
      App.Current.MainWindow.Close();
      Application.SetSuspendState(PowerState.Suspend, true, true);
    }
  }

}
