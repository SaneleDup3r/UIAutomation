using Microsoft.Playwright;

namespace Automation.Pages
{
    public class Computers
    {
        private readonly IPage _page;
        private readonly ILocator _desktops;
        private readonly ILocator _notebooks;
        private readonly ILocator _accessories;

        public Computers(IPage page)
        {
            _page = page;
            _desktops = _page.Locator("//img[@title='Show products in category Desktops']");
            _notebooks = _page.Locator("//img[@title='Show products in category Notebooks']");
            _accessories = _page.Locator("//img[@title='Show products in category Accessories']");
        }

        public async Task ClickOnDesktopAsync()
            => await _desktops.ClickAsync();

        public async Task ClickOnNotebookAsync()
            => await _notebooks.ClickAsync();

        public async Task ClickOnAccessoriesAsync()
            => await _accessories.ClickAsync();
    }
}
