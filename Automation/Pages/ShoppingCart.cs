using Microsoft.Playwright;

namespace Automation.Pages
{
    public class ShoppingCart
    {
        private readonly IPage _page;
        private readonly ILocator _removeItem;
        private readonly ILocator _updateShoppingCartBtn;
        private readonly ILocator _termsOfService;
        private readonly ILocator _checkout;
        private readonly ILocator _getTotalPrice;

        public ShoppingCart(IPage page)
        {
            _page = page;
            _removeItem = _page.Locator("//input[@name='removefromcart']").Last;
            _updateShoppingCartBtn = _page.Locator("//input[@name='updatecart']");
            _termsOfService = _page.Locator("//input[@id='termsofservice']");
            _checkout = _page.Locator("//button[@id='checkout']");
            _getTotalPrice = _page.Locator("//span[@class='product-price order-total']");
        }

        public async Task<string> GetTotalAsync()
            => await _getTotalPrice.InnerTextAsync();

        public async Task ClickCheckoutAsync()
            => await _checkout.ClickAsync();

        public async Task ClickOnTermsOfServiceAsync()
            => await _termsOfService.ClickAsync();

        public async Task ClickUpdateShoppingCartAsync()
            => await _updateShoppingCartBtn.ClickAsync();

        public async Task RemoveItemAsync()
            => await _removeItem.ClickAsync();


    }
}
