using Reqnroll;
using ReqnrollTestProject1.Reports;

namespace ReqnrollTestProject1.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportsManager.InitReport();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            ExtentReportsManager.StartTest(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepInfo = scenarioContext.StepContext.StepInfo.Text;
            bool isSuccess = scenarioContext.TestError == null;
            ExtentReportsManager.LogStep(isSuccess, isSuccess ? $"Paso exitos : {stepInfo}" : $"Error: {scenarioContext.TestError.Message}");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportsManager.flushReport();
        }
    }
}