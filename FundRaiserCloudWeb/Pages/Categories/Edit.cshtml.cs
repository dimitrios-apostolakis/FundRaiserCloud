using FundRaiserCloudWeb.Data;
using FundRaiserWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundRaiserCloudWeb.Pages.Categories
{
    [BindProperties]    //global use of bind
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty]    //more than 1 should be put individually
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
            //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
            //Category = _db.Category.SingleOrDefault(u => u.Id == id);
            //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault;
        }

        public async Task<IActionResult> OnPost()//no bind->(Category category)
        {
            if (Category.Name == Category.DisplayOrder.ToString())  //Custom Validation
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name."); //CustomError || string.Empty || Category.name 
            }

            if (ModelState.IsValid) //Server Side Validation
            {
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
