using Quokka.ListItems;

namespace Plugin_PowerCommands {
  /// <summary>
  /// The context pane for PowerCommands (empty)
  /// </summary>
  public partial class ContextPane : ItemContextPane {

    /// <summary>
    /// Returns users to search
    /// </summary>
    public ContextPane() {
      InitializeComponent();
      base.ReturnToSearch();
    }
  }

}
