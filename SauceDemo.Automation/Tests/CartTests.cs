using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;
using SauceDemo.Automation.Pages;

namespace SauceDemo.Automation.Tests
{
    [TestFixture]
    public class CartTests : PageTest
    {
        [Test]
        public async Task AddProductToCart_ShouldAppearInCart()
        {
            var loginPage = new LoginPage(Page);
            var productsPage = new ProductsPage(Page);
            var cartPage = new CartPage(Page);

            // 1. Login
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync("standard_user", "secret_sauce");

            // 2. Добавяне на продукт
            await productsPage.AddFirstProductToCartAsync();

            // 3. Отваряне на количката
            await productsPage.GoToCartAsync();

            // 4. Проверка, че продуктът е там
            Assert.That(await cartPage.IsProductInCartAsync(), Is.True);

            // Проверка за броя на продуктите в количката
            var itemCount = await cartPage.GetCartItemCountAsync();
            Assert.That(itemCount, Is.EqualTo("1"));
        }
    }
}