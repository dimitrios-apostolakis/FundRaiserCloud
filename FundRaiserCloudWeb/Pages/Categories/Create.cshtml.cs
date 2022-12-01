using FundRaiserCloudWeb.Data;
using FundRaiserWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundRaiserCloudWeb.Pages.Categories
{
    [BindProperties]    //global use of bind
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty]    //more than 1 should be put individually
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()//no bind->(Category category)
        {
            if (Category.Name == Category.DisplayOrder.ToString())  //Custom Validation
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name."); //CustomError || string.Empty || Category.name 
            }

            if (ModelState.IsValid) //Server Side Validation
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
				TempData["success"] = "Category created successfully";
				return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
