using Quokka.ListItems;
using Quokka.PluginArch;
using System;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace Plugin_PowerCommands {
  class SignOutItem : ListItem {

    public SignOutItem() {
      Name = "Sign out";
      Description = "Closes all apps and ends the session (This app is shutdown before the action is carried out)";
      UiDispatcher.BeginInvoke(() => {
        Icon = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\PlugBoard\\Plugin_PowerCommands\\Plugin\\signOut.png"));
      });
    }

    public override void Execute() {
      var psi = new ProcessStartInfo("powershell.exe", "Start-Sleep -Seconds 3; shutdown /l");
      psi.CreateNoWindow = true;
      psi.UseShellExecute = false;
      Process.Start(psi);
      Quokka.App.Current.Shutdown();
    }
  }

}
