using Quokka.ListItems;
using Quokka.PluginArch;
using System.Diagnostics;

namespace PluginPowerCommands
{
  internal sealed class ShutdownItem : ListItem
  {

    public ShutdownItem()
    {
      Name = "Shutdown";
      Description = "Closes all apps and turns off the PC (This app is shutdown before the action is carried out)";
      Icon = IconCache.GetOrAdd(
        Environment.CurrentDirectory + "\\PlugBoard\\PluginPowerCommands\\Plugin\\shutdown.png"
      );
    }

    public override void Execute()
    {
      var psi = new ProcessStartInfo("shutdown", "/sg /t 3")
      {
        CreateNoWindow = true,
        UseShellExecute = false
      };
      Process.Start(psi);
      Quokka.App.Current.Shutdown();
    }
  }

}
