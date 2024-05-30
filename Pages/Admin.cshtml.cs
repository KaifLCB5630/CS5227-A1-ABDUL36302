using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CS5227_A1_ABDUL36302.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CS5227_ABDUL36302.data;
using Microsoft.AspNetCore.Authorization;

namespace CS5227_A1_ABDUL36302.Pages
{
    [Authorize(Roles = "admin")]
    public class AdminModel : PageModel
    {
        private readonly appDBcontext _context;

        public AdminModel(appDBcontext context)
        {
            _context = context;
        }

        public IList<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
        [BindProperty]
        public FoodItem CurrentFoodItem { get; set; }
        public bool IsEditMode { get; set; } = false;

        public async Task<IActionResult> OnGetAsync()
        {
            FoodItems = await _context.FoodItems.ToListAsync();
            if (CurrentFoodItem == null)
            {
                CurrentFoodItem = new FoodItem();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                FoodItems = await _context.FoodItems.ToListAsync();
                return Page();
            }

            if (CurrentFoodItem.Id > 0)
            {
                // Update existing item
                _context.Attach(CurrentFoodItem).State = EntityState.Modified;
            }
            else
            {
                // Create new item
                _context.FoodItems.Add(CurrentFoodItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem != null)
            {
                _context.FoodItems.Remove(foodItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int id)
        {
            CurrentFoodItem = await _context.FoodItems.FindAsync(id);
            if (CurrentFoodItem == null)
            {
                return NotFound();
            }
            IsEditMode = true;
            FoodItems = await _context.FoodItems.ToListAsync();
            return Page();
        }
    }
}
