using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Drawing;

namespace AppiumTest
{
    public class Tests : TestBase
    {
        [SetUp]
        public void BeforeAll() {
            Assert.AreNotEqual(
                "Please update value for the KobitonApiKey constant first. See more at README.md file.",
                "your_kobiton_api_key",
                Config.KobitonApiKey
            );
        }

        {{testCases}}
        public void RunTest()
        {
            try
            {
                UpdateSettings();
                SwitchToNativeContext();
                SetImplicitWaitInMiliSecond(Config.ImplicitWaitInMs);
                {{testScript}}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                SaveDebugResource();
                throw;
            }
        }

        public override void Setup(AppiumOptions desiredCaps, double retinaScale)
        {
            base.Setup(desiredCaps, retinaScale);
            Console.WriteLine($"View session at: {{portalUrl}}/session/{GetKobitonSessionId()}");
        }

        [TearDown]
        public void TearDown() {
            base.Cleanup();
        }
    }
}