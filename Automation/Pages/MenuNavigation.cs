using Microsoft.Playwright;

namespace Automation.Pages
{
    public class MenuNavigation
    {
        private readonly IPage _page;
        private readonly ILocator _register;
        private readonly ILocator _login;
        private readonly ILocator _shoppingCart;
        private readonly ILocator _wishlist;
        private readonly ILocator _computers;

        public MenuNavigation(IPage page)
        {
            _page = page;
            _register = _page.Locator("//a[@class='ico-register']");
            _login = _page.Locator("//a[@class='ico-login']");
            _shoppingCart = _page.Locator("(//a[@class='ico-cart'])[1]");
            _wishlist = _page.Locator("(//a[@class='ico-wishlist'])[1]");
            _computers = _page.Locator("(//a[contains(text(),'Computers')])[1]");
        }
        
        public async Task ClickOnRegisterAsync()
            => await _register.ClickAsync();

        public async Task ClickOnLoginAsync()
            => await _login.ClickAsync();

        public async Task ClickOnShoppingCartAsync()
            => await _shoppingCart.ClickAsync();

        public async Task ClickOnWishlistAsync()
            => await _wishlist.ClickAsync();

        public async Task ClickOnComputersAsync()
            => await _computers.ClickAsync();
    }
}
