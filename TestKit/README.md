# TestKit Documentation

## Class: `Test`

The `Test` class is the primary interface for users to define and execute feature tests on their code. It provides methods to specify features, add feature tests, and run these tests to evaluate the performance and correctness of the features.

### Constructor

- **`Test(string name, string[]? features = null)`**
  - **Parameters:**
    - `name`: A string representing the name of the test suite.
    - `features`: An optional array of strings specifying initial features to be tested.

### Methods

#### `AddFeature`

- **`Test AddFeature(string feature)`**
  - **Description:** Adds a new feature to the test suite. This feature will be tracked and evaluated during test execution.
  - **Parameters:**
    - `feature`: A string representing the name of the feature to be added.
  - **Returns:** The current instance of the `Test` class, allowing for method chaining.

#### `AddFeatureTest`

- **`void AddFeatureTest(string description, string[] testedFeatures, Action testLogic)`**
  - **Description:** Adds a new feature test to the test suite. A feature test is a specific test case that verifies one or more features.
  - **Parameters:**
    - `description`: A string providing a human-readable description of the feature test.
    - `testedFeatures`: An array of strings listing the features that this test verifies.
    - `testLogic`: An `Action` delegate containing the logic to be executed for this test. This is the code that performs the described action.

#### `Run`

- **`void Run()`**
  - **Description:** Executes all the added feature tests in the order they were added. After execution, it evaluates and logs a report detailing the performance time and the success or failure of each feature test.
  - **Behavior:**
    - Logs the start of the test suite execution.
    - For each feature test, it attempts to execute the test logic.
    - Updates the status of each feature based on the test results.
    - Logs a detailed report for each feature, indicating whether all tests passed, some tests passed, or all tests failed.

### Usage Example

```csharp
var testSuite = new Test("MyFeatureTests");
testSuite.AddFeature("FeatureA")
         .AddFeature("FeatureB");

testSuite.AddFeatureTest(
    "Test FeatureA functionality",
    new[] { "FeatureA" },
    () => {
        // Test logic for FeatureA
    }
);

testSuite.Run();
```
