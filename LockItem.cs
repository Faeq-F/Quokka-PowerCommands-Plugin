using Quokka;
using Quokka.ListItems;
using Quokka.PluginArch;
using System.Runtime.InteropServices;

namespace PluginPowerCommands
{
  internal sealed class LockItem : ListItem
  {

    [DllImport("user32.dll")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern void LockWorkStation();

    public LockItem()
    {
      Name = "Lock";
      Description = "Secure your PC, requiring a password to resume your session";
      Icon = IconCache.GetOrAdd(
        Environment.CurrentDirectory + "\\PlugBoard\\PluginPowerCommands\\Plugin\\lock.png"
      );
    }

    public override void Execute()
    {
      App.Current.MainWindow.Close();
      LockWorkStation();
    }
  }

}
