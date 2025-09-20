using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;
using SauceDemo.Automation.Pages;

namespace SauceDemo.Automation.Tests
{
    [TestFixture]
    public class LoginTests : PageTest
    {
        [Test]
        public async Task SuccessfulLogin()
        {
            var loginPage = new LoginPage(Page);

            await loginPage.NavigateAsync();
            await loginPage.LoginAsync("standard_user", "secret_sauce");

            Assert.That(await Page.TitleAsync(), Is.EqualTo("Swag Labs"));
        }

        // [Test]
        // public async Task InvalidLogin_ShowsErrorMessage()
        // {
        //     var loginPage = new LoginPage(Page);
        //
        //     await loginPage.NavigateAsync();
        //     await loginPage.LoginAsync("standard_user", "wrong_password");
        //
        //     // Проверка дали error съобщението е видимо
        //     Assert.That(await loginPage.IsErrorVisibleAsync(), Is.True);
        //
        //     // Проверка за текста
        //     var errorMessage = await loginPage.GetErrorMessageAsync();
        //     Assert.That(errorMessage, Does.Contain("Username and password do not match any user in this service"));
        // }
    }
}
