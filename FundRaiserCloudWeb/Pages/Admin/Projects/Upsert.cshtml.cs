using FundRaiser.DataAccess.Data;
using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundRaiserCloudWeb.Pages.Admin.Projects
{
    [BindProperties]    //global use of bind
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        //[BindProperty]    //more than 1 should be put individually
        public Project Project { get; set; }
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Project = new();
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()//no bind->(Category category)
        {
            //if (ModelState.IsValid) //Server Side Validation
            //{
            //    _unitOfWork.Project.Add(Project);
            //    _unitOfWork.Save();
            //    TempData["success"] = "Category created successfully";
            //    return RedirectToPage("Index");
            //}
            return Page();
        }
    }
}
