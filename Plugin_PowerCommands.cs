using Newtonsoft.Json;
using Quokka.ListItems;
using Quokka.PluginArch;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Plugin_PowerCommands {
  /// <summary>
  /// The Power Commands plugin
  /// </summary>
  public partial class PowerCommands : Plugin {

    private static Settings pluginSettings = new();
    internal static Settings PluginSettings { get => pluginSettings; set => pluginSettings = value; }

    /// <summary>
    /// Creates the plugin, loading the plugins settings
    /// </summary>
    public PowerCommands() {
      string fileName = Environment.CurrentDirectory + "\\PlugBoard\\Plugin_PowerCommands\\Plugin\\settings.json";
      PluginSettings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(fileName))!;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override string PluggerName { get; set; } = "PowerCommands";

    /// <summary>
    /// <inheritdoc/><br />
    /// Provides the relevant power commands close enough (fuzzy search) to either the command in settings or it's name. 'Sign Out' is also compared to 'log off'
    /// </summary>
    /// <param name="query"><inheritdoc /></param>
    /// <returns>power commands that are close enough to the query</returns>
    public override List<ListItem> OnQueryChange(string query) {
      List<String> commands = SpecialCommands();
      commands.RemoveAt(0);
      List<ListItem> items = new List<ListItem>() {
        new LockItem(),
        new RestartItem(),
        new SleepItem(),
        new ShutdownItem(),
        new SignOutItem(),
      };
      return FuzzySearch.searchAll(query, commands, PluginSettings.FuzzySearchThreshold)
        .Select(x => items[x.Index]).ToList();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns>The commands in settings (all power commands are special commands)</returns>
    public override List<String> SpecialCommands() {
      return new List<String>() { PluginSettings.AllPowerCommandsCommand,
        PluginSettings.LockCommand, PluginSettings.RestartCommand,
        PluginSettings.SleepCommand, PluginSettings.ShutdownCommand, PluginSettings.SignOutCommand };
    }

    /// <summary>
    /// <inheritdoc/><br />
    /// Provides the respective power command or all of them if the query is the AllPowerCommandsCommand
    /// </summary>
    /// <param name="command"><inheritdoc/></param>
    /// <returns>the respective power command</returns>
    public override List<ListItem> OnSpecialCommand(string command) {
      switch (command) {
        case var value when value == PluginSettings.LockCommand: return new List<ListItem>() { new LockItem() };
        case var value when value == PluginSettings.RestartCommand: return new List<ListItem>() { new RestartItem() };
        case var value when value == PluginSettings.ShutdownCommand: return new List<ListItem>() { new ShutdownItem() };
        case var value when value == PluginSettings.SleepCommand: return new List<ListItem>() { new SleepItem() };
        case var value when value == PluginSettings.SignOutCommand: return new List<ListItem>() { new SignOutItem() };
        default: return new List<ListItem>() { new LockItem(), new SignOutItem(), new SleepItem(), new RestartItem(), new ShutdownItem() };
      }
    }

  }

}
