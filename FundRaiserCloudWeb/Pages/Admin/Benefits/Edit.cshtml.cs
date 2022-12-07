using FundRaiser.DataAccess.Data;
using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
//using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundRaiserCloudWeb.Pages.Admin.Benefits
{
    [BindProperties]    //global use of bind
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        //[BindProperty]    //more than 1 should be put individually
        public Benefit Benefit { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            //Category = _unitOfWork.Category.Find(id);
            Benefit = _unitOfWork.Benefit.GetFirstOrDefault(u=>u.Id==id);
            //Category = _db.Category.SingleOrDefault(u => u.Id == id);
            //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault;
        }

        public async Task<IActionResult> OnPost()//no bind->(Category category)
        {
            //if (Category.Name == Category.DisplayOrder.ToString())  //Custom Validation
            //{
            //    ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name."); //CustomError || string.Empty || Category.name 
            //}

            if (ModelState.IsValid) //Server Side Validation
            {
                _unitOfWork.Benefit.Update(Benefit);
                _unitOfWork.Save();
				TempData["success"] = "Benefit updated successfully";
				return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
