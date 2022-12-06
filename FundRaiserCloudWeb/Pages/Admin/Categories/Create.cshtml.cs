using FundRaiser.DataAccess.Data;
using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundRaiserCloudWeb.Pages.Admin.Categories
{
    [BindProperties]    //global use of bind
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        //[BindProperty]    //more than 1 should be put individually
        public Category Category { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()//no bind->(Category category)
        {
            //if (Category.Name == Category.DisplayOrder.ToString())  //Custom Validation
            //{
            //    ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name."); //CustomError || string.Empty || Category.name 
            //}

            if (ModelState.IsValid) //Server Side Validation
            {
                _unitOfWork.Category.Add(Category);
                _unitOfWork.Save();
				TempData["success"] = "Category created successfully";
				return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
