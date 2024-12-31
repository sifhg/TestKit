namespace TestKit.utils;

public readonly struct FeatureTest
{
  public string Description { get; init; }
  public string[] TestedFeatures { get; init; }
  public Action TestLogic { get; init; }
}