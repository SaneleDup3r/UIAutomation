using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Automation.Tests.Setup
{
    public class BasePageTest : PageTest
    {
        [SetUp]
        public async Task SetupAsync()
        {
            await Page.GotoAsync(TestContext.Parameters["AppUrl"]);
        }

        public override BrowserNewContextOptions ContextOptions()
        {
            return new()
            {
                ViewportSize = new ViewportSize { Width = 1920, Height = 1080 }
            };
        }
    }
}
