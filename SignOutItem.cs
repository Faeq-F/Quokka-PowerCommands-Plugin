using Quokka.ListItems;
using Quokka.PluginArch;
using System.Diagnostics;

namespace PluginPowerCommands
{
  internal sealed class SignOutItem : ListItem
  {

    public SignOutItem()
    {
      Name = "Sign out";
      Description = "Closes all apps and ends the session (This app is shutdown before the action is carried out)";
      Icon = IconCache.GetOrAdd(
        Environment.CurrentDirectory + "\\PlugBoard\\PluginPowerCommands\\Plugin\\signOut.png"
      );
    }

    public override void Execute()
    {
      var psi = new ProcessStartInfo("powershell.exe", "Start-Sleep -Seconds 3; shutdown /l")
      {
        CreateNoWindow = true,
        UseShellExecute = false
      };
      Process.Start(psi);
      Quokka.App.Current.Shutdown();
    }
  }

}
