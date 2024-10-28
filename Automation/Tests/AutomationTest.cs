using Automation.Tests.Setup;
using NUnit.Framework;
using Automation.Pages;

namespace Automation.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class AutomationTest : BasePageTest
    {
        [Test(Description = "Automation Test"), Retry(2)]
        public async Task Register()
        {
            
            var firstName = "Sanele";
            var lastName = "Gwiji";
            var email = "SuperDuper13@example.com";
            var password = "password";

            //Navigating to White Papers & eBooks
            var menuNavigation = new MenuNavigation(Page);
            await menuNavigation.ClickOnRegisterAsync();

            //Fill in user details
            var register = new Register(Page);
            await register.SelectGenderAsync(Gender.Male);
            await register.EnterFirstNameAsync(firstName);
            await register.EnterLastNameAsync(lastName);
            await register.EnterEmailAsync(email);
            await register.EnterPasswordAsync(password);
            await register.ReEnterPasswordAsync(password);
            await register.ClickOnRegisterAsync();

            var landingPage = new LandingPage(Page);
            await landingPage.ClickOnContinueAsync();
            
            await menuNavigation.ClickOnComputersAsync();

            var computers = new Computers(Page);
            await computers.ClickOnDesktopAsync();

            //Adding Items to shopping cart
            var desktopLandingPage = new DesktopLandingPage(Page);
            await desktopLandingPage.SortByAsync();
            await desktopLandingPage.AddToCartAsync();

            await menuNavigation.ClickOnShoppingCartAsync();
            
            //Removing items on a shopping cart
            var shoppingCart = new ShoppingCart(Page);
            var totalBefore = await shoppingCart.GetTotalAsync();
            await shoppingCart.RemoveItemAsync();
            await shoppingCart.ClickUpdateShoppingCartAsync();
            var totalAfter = await shoppingCart.GetTotalAsync();

            var total1 = totalBefore.Replace(".00","");
            var total2 = totalAfter.Replace(".00", "");

            //Assert
            Assert.That(Convert.ToInt32(total1), Is.GreaterThan(Convert.ToInt32(total2)));

            await shoppingCart.ClickOnTermsOfServiceAsync();
            await shoppingCart.ClickCheckoutAsync();

            //Checkout
            var checkOutPage = new CheckOutPage(Page);
            await checkOutPage.FillInBillingInfo("South Amaerica", "123 Address 1", "1192", "0112933122");
            await checkOutPage.BillingContinueAsync();
            await checkOutPage.ShippingContinueAsync();
            await checkOutPage.ShippingMethodContinueAsync();
            await checkOutPage.PaymentMethodContinueAsync();
            await checkOutPage.PaymentInfoContinueAsync();
            await checkOutPage.ConfirmOrderAsync();
            await checkOutPage.GetTitle();
            var successful = await checkOutPage.GetSuccessStatus();

            Assert.That(successful, Is.EqualTo("Your order has been successfully processed!"));
        }
    }               
}
