using Microsoft.Playwright;

namespace Automation.Pages
{
    public class CheckOutPage
    {
        private readonly IPage _page;
        private readonly ILocator _billingContinue;
        private readonly ILocator _shippingContinue;
        private readonly ILocator _shippingMethodContinue;
        private readonly ILocator _paymentMethodContinue;
        private readonly ILocator _paymentInfoContinue;
        private readonly ILocator _confirmOrder;
        private readonly ILocator _thankYouHeader;
        private readonly ILocator _title;

        //Billing Info
        private readonly ILocator _country;
        private readonly ILocator _city;
        private readonly ILocator _address1;
        private readonly ILocator _zipCode;
        private readonly ILocator _phoneNumber;

        public CheckOutPage(IPage page)
        {
            _page = page;
            _billingContinue = _page.Locator("//input[@onclick='Billing.save()']");
            _shippingContinue = _page.Locator("//input[@onclick='Shipping.save()']");
            _shippingMethodContinue = _page.Locator("//input[@onclick='ShippingMethod.save()']");
            _paymentMethodContinue = _page.Locator("//input[@onclick='PaymentMethod.save()']");
            _paymentInfoContinue = _page.Locator("//input[@value='Continue']").Last;
            _confirmOrder = _page.Locator("//input[@value='Confirm']");
            _title = _page.Locator(".checkout-page .title");
            _thankYouHeader = _page.Locator("//h1[contains(text(),'Thank you')]");

            _country = _page.Locator("//select[@id='BillingNewAddress_CountryId']");
            _city = _page.Locator("//input[@id='BillingNewAddress_City']");
            _address1 = _page.Locator("//input[@id='BillingNewAddress_Address1']");
            _zipCode = _page.Locator("//input[@id='BillingNewAddress_ZipPostalCode']");
            _phoneNumber = _page.Locator("//input[@id='BillingNewAddress_PhoneNumber']");
        }

        public async Task BillingContinueAsync()
            => await _billingContinue.ClickAsync();

        public async Task ShippingContinueAsync()
           => await _shippingContinue.ClickAsync();

        public async Task ShippingMethodContinueAsync()
          => await _shippingMethodContinue.ClickAsync();

        public async Task PaymentMethodContinueAsync()
          => await _paymentMethodContinue.ClickAsync();

        public async Task PaymentInfoContinueAsync()
          => await _paymentInfoContinue.ClickAsync();

        public async Task ConfirmOrderAsync()
          => await _confirmOrder.ClickAsync();

        public async Task<string> GetTitle()
            => await _thankYouHeader.InnerTextAsync();

        public async Task<string> GetSuccessStatus()
            => await _title.InnerTextAsync();

        public async Task FillInBillingInfo(string city,string address1,string zipCode,string phoneNumber)
        {
            await _country.SelectOptionAsync( new [] { new SelectOptionValue() { Index = 2 } });
            await _city.FillAsync(city);
            await _address1.FillAsync(address1);
            await _zipCode.FillAsync(zipCode);
            await _phoneNumber.FillAsync(phoneNumber);
        }
    }

}
