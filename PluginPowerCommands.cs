using Newtonsoft.Json;
using Quokka.ListItems;
using Quokka.PluginArch;
using System.Collections.ObjectModel;
using System.IO;

namespace PluginPowerCommands
{
  /// <summary>
  /// The Power Commands plugin
  /// </summary>
  public partial class PowerCommands : Plugin
  {
    internal static Settings PluginSettings { get; set; } = new();

    /// <summary>
    /// Creates the plugin, loading the plugins settings
    /// </summary>
    public PowerCommands()
    {
      string fileName = Environment.CurrentDirectory + "\\PlugBoard\\PluginPowerCommands\\Plugin\\settings.json";
      PluginSettings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(fileName))!;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override string PluginName { get; set; } = "PowerCommands";

    /// <summary>
    /// <inheritdoc/><br />
    /// Provides the relevant power commands close enough (fuzzy search) to either the command in settings or it's name. 'Sign Out' is also compared to 'log off'
    /// </summary>
    /// <param name="query"><inheritdoc /></param>
    /// <returns>power commands that are close enough to the query</returns>
    public override Collection<ListItem> OnQueryChange(string query)
    {
      Collection<String> commands = SpecialCommands();
      commands.RemoveAt(0);
      List<ListItem> items = new() {
        new LockItem(),
        new RestartItem(),
        new SleepItem(),
        new ShutdownItem(),
        new SignOutItem(),
      };
      return new Collection<ListItem>(
        FuzzySearch.SearchAll(query, commands, PluginSettings.FuzzySearchThreshold)
        .Select(x => items[x.Index]).ToList());
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns>The commands in settings (all power commands are special commands)</returns>
    public override Collection<String> SpecialCommands()
    {
      return new Collection<String>() { PluginSettings.AllPowerCommandsCommand,
        PluginSettings.LockCommand, PluginSettings.RestartCommand,
        PluginSettings.SleepCommand, PluginSettings.ShutdownCommand, PluginSettings.SignOutCommand };
    }

    /// <summary>
    /// <inheritdoc/><br />
    /// Provides the respective power command or all of them if the query is the AllPowerCommandsCommand
    /// </summary>
    /// <param name="command"><inheritdoc/></param>
    /// <returns>the respective power command</returns>
    public override Collection<ListItem> OnSpecialCommand(string command)
    {
      return command switch
      {
        var value when value == PluginSettings.LockCommand => new Collection<ListItem>() { new LockItem() },
        var value when value == PluginSettings.RestartCommand => new Collection<ListItem>() { new RestartItem() },
        var value when value == PluginSettings.ShutdownCommand => new Collection<ListItem>() { new ShutdownItem() },
        var value when value == PluginSettings.SleepCommand => new Collection<ListItem>() { new SleepItem() },
        var value when value == PluginSettings.SignOutCommand => new Collection<ListItem>() { new SignOutItem() },
        _ => new Collection<ListItem>() { new LockItem(), new SignOutItem(), new SleepItem(), new RestartItem(), new ShutdownItem() },
      };
    }

  }

}
