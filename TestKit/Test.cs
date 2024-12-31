using TestKit.utils;
namespace TestKit;

public class Test
{
  public string Name { get; init; }
  public Dictionary<string, TestCompletion> TestCompletions { get; init; }
  public List<FeatureTest> FeatureTests { get; init; }

  public Test(string name, string[]? features = null)
  {
    Name = name;
    TestCompletions = [];
    FeatureTests = [];
    if (features is null)
    {
      return;
    }

    foreach (string feature in features)
    {
      TestCompletions.Add(feature, default);
    }
  }

  public void AddFeatureTest(string description, string[] testedFeatures, Action testLogic)
  {
    foreach (string feature in testedFeatures)
    {
      if (!TestCompletions.ContainsKey(feature))
      {
        AddFeature(feature);
      }
    }

    FeatureTest newFeatureTest = new()
    {
      Description = description,
      TestedFeatures = testedFeatures,
      TestLogic = testLogic
    };
    FeatureTests.Add(newFeatureTest);
  }

  public Test AddFeature(string feature)
  {
    TestCompletions.Add(feature, default);
    return this;
  }

  public void Run()
  {
    utils.TestUtilities.LogInfo($"\nRunning {Name}...");

    foreach (FeatureTest featureTest in FeatureTests)
    {
      if (utils.TestUtilities.TryExecute(featureTest.Description, featureTest.TestLogic))
      {
        foreach (string feature in featureTest.TestedFeatures)
        {
          TestCompletion newValue = TestCompletions[feature].Pass();
          TestCompletions[feature] = newValue;
        }
      }
      else
      {
        foreach (string feature in featureTest.TestedFeatures)
        {
          TestCompletion newValue = TestCompletions[feature].Fail();
          TestCompletions[feature] = newValue;
        }
      }
    }

    foreach (string feature in TestCompletions.Keys)
    {
      Console.WriteLine($"\nTests of {feature}:");
      string evaluation = TestCompletions[feature].EvaluateTest();
      if (TestCompletions[feature].DidAllTestsPass())
      {
        utils.TestUtilities.LogSuccess(evaluation);
      }
      else if (TestCompletions[feature].DidAnyTestsPass())
      {
        utils.TestUtilities.LogWarning(evaluation);
      }
      else
      {
        utils.TestUtilities.LogError(evaluation);
      }
    }
  }
}