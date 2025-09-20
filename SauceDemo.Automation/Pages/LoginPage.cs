using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemo.Automation.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        // Locators
        private ILocator UsernameInput => _page.Locator("[data-test='username']");
        private ILocator PasswordInput => _page.Locator("[data-test='password']");
        private ILocator LoginButton => _page.Locator("[data-test='login-button']");
        private ILocator ErrorMessage => _page.Locator("[data-test='error']");

        // Навигация към сайта
        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
        }

        // Действие за логин
        public async Task LoginAsync(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }

        // Взимане на текста от error съобщението
        // public async Task<string> GetErrorMessageAsync()
        // {
        //     return await ErrorMessage.InnerTextAsync();
        // }
        //
        // // Проверка дали error съобщението е видимо
        // public async Task<bool> IsErrorVisibleAsync()
        // {
        //     return await ErrorMessage.IsVisibleAsync();
        // }
    }
}