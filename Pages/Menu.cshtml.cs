using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CS5227_A1_ABDUL36302.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS5227_ABDUL36302.data;
using Microsoft.AspNetCore.Mvc;

namespace CS5227_A1_ABDUL36302.Pages
{
    public class MenuModel : PageModel
    {
        private readonly appDBcontext _context;

        public MenuModel(appDBcontext context)
        {
            _context = context;
        }

        public IList<FoodItem> FoodItems { get; set; }
        public string SearchQuery { get; set; }

        public async Task OnGetAsync(string searchQuery)
        {
            SearchQuery = searchQuery;
            var query = _context.FoodItems.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(item => item.Name.Contains(searchQuery) ||
                                            item.Description.Contains(searchQuery) ||
                                            item.Category.Contains(searchQuery));
            }

            FoodItems = await query.ToListAsync();
        }

        public IActionResult OnPostAddToCart(int id)
        {
            var foodItem = _context.FoodItems.Find(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            var cart = HttpContext.Session.GetCart();
            var cartItem = cart.FirstOrDefault(ci => ci.FoodItemId == id);

            if (cartItem == null)
            {
                cart.Add(new CartItem { FoodItemId = foodItem.Id, Name = foodItem.Name, Price = foodItem.Price, Quantity = 1 });
            }
            else
            {
                cartItem.Quantity++;
            }

            HttpContext.Session.SetCart(cart);

            return RedirectToPage();
        }
    }
}
