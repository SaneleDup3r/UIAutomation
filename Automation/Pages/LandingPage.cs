using Microsoft.Playwright;

namespace Automation.Pages
{
    public class LandingPage
    {
        private readonly IPage _page;
        private readonly ILocator _continueBtn;


        public LandingPage(IPage page)
        {
            _page = page;
            _continueBtn = _page.Locator("//input[@value='Continue']");
        }

        public async Task ClickOnContinueAsync()
            => await _continueBtn.ClickAsync();

    }
}
