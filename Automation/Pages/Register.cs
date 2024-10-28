using Microsoft.Playwright;

static class Gender
{
    public const string Male = "Male";
    public const string Female = "Female";
}
namespace Automation.Pages
{

    public class Register
    {
        private readonly IPage _page;
        private readonly ILocator _firstName;
        private readonly ILocator _lastName;
        private readonly ILocator _email;
        private readonly ILocator _password;
        private readonly ILocator _retypePassword;
        private readonly ILocator _registerBtn;

        public Register(IPage page)
        {
            _page = page;
            _firstName = _page.Locator("//input[@id='FirstName']");
            _lastName = _page.Locator("//input[@id='LastName']");
            _email = _page.Locator("//input[@id='Email']");
            _password = _page.Locator("//input[@id='Password']");
            _retypePassword = _page.Locator("//input[@id='ConfirmPassword']");
            _registerBtn = _page.Locator("//input[@id='register-button']");
        }

        public async Task SelectGenderAsync(string gender)
        {
            var _gender = "(//input[@type='radio'])";

            if (gender == Gender.Male)
                await _page.Locator(_gender + "[1]").ClickAsync();
            else if (gender == Gender.Female)
                await _page.Locator(_gender + "[2]").ClickAsync();
        }

        public async Task EnterFirstNameAsync(string firstName)
            => await _firstName.FillAsync(firstName);

        public async Task EnterLastNameAsync(string lastName)
            => await _lastName.FillAsync(lastName);

        public async Task EnterEmailAsync(string email)
            => await _email.FillAsync(email);

        public async Task EnterPasswordAsync(string password)
            => await _password.FillAsync(password);

        public async Task ReEnterPasswordAsync(string password)
            => await _retypePassword.FillAsync(password);

        public async Task ClickOnRegisterAsync()
            => await _registerBtn.ClickAsync();
           
    }
}
