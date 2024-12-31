namespace TestKit.utils;

public struct TestCompletion
{
  public ushort TotalTests { get; init; }
  public ushort PassedTests { get; init; }
  public TestCompletion Pass()
  {
    return new() { TotalTests = (ushort)(TotalTests + 1), PassedTests = (ushort)(PassedTests + 1) };
  }
  public TestCompletion Fail()
  {
    return new() { TotalTests = (ushort)(TotalTests + 1), PassedTests = PassedTests };
  }
  public readonly string EvaluateTest()
  {
    if (TotalTests == 0)
    {
      return "(no tests run)";
    }
    return $"{(float)PassedTests / TotalTests * 100:F2}%\n{PassedTests} out of {TotalTests} tests passed";
  }
  public readonly bool DidAllTestsPass()
  {
    return TotalTests != 0 && PassedTests == TotalTests;
  }
  public readonly bool DidAnyTestsPass()
  {
    return PassedTests != 0;
  }
}