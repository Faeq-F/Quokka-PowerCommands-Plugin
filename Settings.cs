/// <summary>
/// The plugin's settings
/// </summary>
public class Settings {
  /// <summary>
  /// The special command to list all power commands. Defaults to "PowerCommands"
  /// </summary>
  public string AllPowerCommandsCommand { get; set; } = "PowerCommands";
  /// <summary>
  /// The Special command to show the shutdown item. Defaults to "shutdown"
  /// </summary>
  public string ShutdownCommand { get; set; } = "shutdown";
  /// <summary>
  /// /// The Special command to show the restart item. Defaults to "restart"
  /// </summary>
  public string RestartCommand { get; set; } = "restart";
  /// <summary>
  /// The Special command to show the sleep item. Defaults to "sleep"
  /// </summary>
  public string SleepCommand { get; set; } = "sleep";
  /// <summary>
  /// The Special command to show the sign out item. Defaults to "sign out"
  /// </summary>
  public string SignOutCommand { get; set; } = "sign out";
  /// <summary>
  /// The Special command to show the lock command. Defaults to "lock"
  /// </summary>
  public string LockCommand { get; set; } = "lock";
  /// <summary>
  ///   The threshold for when to consider an application
  ///   name is similar enough to the query for it to be
  ///   displayed (defaults to 5). Currently uses the
  ///   Levenshtein distance; the larger the number, the
  ///   bigger the difference.
  /// </summary>
  public int FuzzySearchThreshold { get; set; } = 5;
}

