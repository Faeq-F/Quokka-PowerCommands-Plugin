using Quokka;
using Quokka.ListItems;
using Quokka.PluginArch;
using System;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

namespace Plugin_PowerCommands {
  class LockItem : ListItem {

    [DllImport("user32.dll")]
    public static extern void LockWorkStation();

    public LockItem() {
      Name = "Lock";
      Description = "Secure your PC, requiring a password to resume your session";
      UiDispatcher.BeginInvoke(() => {
        Icon = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\PlugBoard\\Plugin_PowerCommands\\Plugin\\lock.png"));
      });
    }

    public override void Execute() {
      App.Current.MainWindow.Close();
      LockWorkStation();
    }
  }

}
