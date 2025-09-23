using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemo.Automation.Pages
{
    public class ProductsPage
    {
        private readonly IPage _page;

        public ProductsPage(IPage page)
        {
            _page = page;
        }

        // Locators
        private ILocator FirstProductAddToCartButton => _page.Locator("[data-test='add-to-cart-sauce-labs-backpack']");
        private ILocator ShoppingCartLink => _page.Locator(".shopping_cart_link");

        // Добавяне на продукт в количката
        public async Task AddFirstProductToCartAsync()
        {
            await FirstProductAddToCartButton.ClickAsync();
        }

        // Навигация към количката
        public async Task GoToCartAsync()
        {
            await ShoppingCartLink.ClickAsync();
        }
    }
}