using FundRaiser.DataAccess.Data;
using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.ObjectModelRemoting;

namespace FundRaiserCloudWeb.Pages.Admin.Benefits
{
    [BindProperties]    //global use of bind
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        //[BindProperty]    //more than 1 should be put individually
        public Benefit Benefit { get; set; }
        public IEnumerable<SelectListItem> ProjectList { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            ProjectList = _unitOfWork.Project.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.Id.ToString()
            });
        }

        public async Task<IActionResult> OnPost()//no bind->(Category category)
        {
            //if (Category.Name == Category.DisplayOrder.ToString())  //Custom Validation
            //{
            //    ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name."); //CustomError || string.Empty || Category.name 
            //}

            if (ModelState.IsValid) //Server Side Validation
            {
                _unitOfWork.Benefit.Add(Benefit);
                _unitOfWork.Save();
				TempData["success"] = "Benefit created successfully";
				return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
