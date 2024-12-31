namespace TestKit.utils;

public static class TestUtilities
{
  // Console utilities
  public static void LogSuccess(string message) => WriteLineColored(message, ConsoleColor.Green);
  public static void LogError(string message) => WriteLineColored(message, ConsoleColor.Red);
  public static void LogWarning(string message) => WriteLineColored(message, ConsoleColor.Yellow);
  public static void LogInfo(string message) => WriteLineColored(message, ConsoleColor.Cyan);
  public static void WriteLineColored(string message, ConsoleColor color = ConsoleColor.White)
  {
    var originalColor = Console.ForegroundColor;
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ForegroundColor = originalColor;
  }
  
  // Execution utilities
  public static TimeSpan MeasureExecutionTime(Action action)
  {
    var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    action();
    stopwatch.Stop();
    return stopwatch.Elapsed;
  }
  public static bool TryExecute(string actionDescription, Action action)
  {
    try
    {
      var executionTime = MeasureExecutionTime(action);
      LogSuccess($"Passed action: {actionDescription}");
      LogInfo($"Execution time: {executionTime.TotalMilliseconds} ms");
      return true;
    }
    catch (Exception ex)
    {
      LogWarning(ex.Message);
      LogError($"Failed action: {actionDescription}");
      return false;
    }
  }
}