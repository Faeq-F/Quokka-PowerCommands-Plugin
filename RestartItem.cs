using Quokka.ListItems;
using Quokka.PluginArch;
using System.Diagnostics;

namespace PluginPowerCommands
{
  class RestartItem : ListItem
  {

    public RestartItem()
    {
      Name = "Restart";
      Description = "Closes all apps, turns off the PC and then turns it on again (This app is shutdown before the action is carried out)";
      Icon = IconCache.GetOrAdd(
        Environment.CurrentDirectory + "\\PlugBoard\\PluginPowerCommands\\Plugin\\restart.png"
      );
    }

    public override void Execute()
    {
      var psi = new ProcessStartInfo("shutdown", "/g /t 3")
      {
        CreateNoWindow = true,
        UseShellExecute = false
      };
      Process.Start(psi);
      Quokka.App.Current.Shutdown();
    }
  }

}
