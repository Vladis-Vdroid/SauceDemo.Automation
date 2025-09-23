using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemo.Automation.Pages
{
    public class CartPage
    {
        private readonly IPage _page;

        public CartPage(IPage page)
        {
            _page = page;
        }

        // Locators
        private ILocator CartItem => _page.Locator(".cart_item");
        private ILocator CartBadge => _page.Locator(".shopping_cart_badge");

        // Проверка дали продуктът е в количката
        public async Task<bool> IsProductInCartAsync()
        {
            return await CartItem.IsVisibleAsync();
        }

        // Проверка броя на продуктите в количката
        public async Task<string> GetCartItemCountAsync()
        {
            return await CartBadge.InnerTextAsync();
        }
    }
}