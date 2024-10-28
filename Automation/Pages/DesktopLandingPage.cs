using Microsoft.Playwright;

namespace Automation.Pages
{
    public class DesktopLandingPage
    {
        private readonly IPage _page;
        private readonly ILocator _sortBy;
        private readonly ILocator _addToCart;
        private readonly ILocator _hdd;
        private readonly ILocator _addToCartBtn;


        public DesktopLandingPage(IPage page)
        {
            _page = page;
            _sortBy = _page.Locator("//select[@id='products-orderby']");
            _addToCart = _page.Locator("//input[@value='Add to cart']");
            _hdd = _page.Locator("(//label[contains(text(),'HDD')]//following::input)[1]");
            _addToCartBtn = _page.Locator("(//input[@value='Add to cart'])[1]");
        }

        public async Task SortByAsync()
            => await _sortBy.SelectOptionAsync(new[] {
                "Position",
                "Name: A to Z",
                "Name: Z to A",
                "Price: Low to High",
                "Price: High to Low",
                "Created on" });

        public async Task AddToCartAsync()
        {
            int[] addBtn = { 1, 3};

            for (int i = 0; i < addBtn.Length; i++)
            {
                await _page.Locator("(//input[@value='Add to cart'])["+ addBtn[i] + "]").ClickAsync();
                await SelectHDDAsync();
                await ClickAddCartBtnAsync();
                await _page.GoBackAsync();
            }
        }

       public async Task SelectHDDAsync()
            => await _hdd.ClickAsync();

       public async Task ClickAddCartBtnAsync()
            => await _addToCartBtn.ClickAsync();
    }
}
