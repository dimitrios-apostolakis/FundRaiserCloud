using FundRaiser.DataAccess.Data;
using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundRaiserCloudWeb.Pages.Admin.Benefits
{
    [BindProperties]    //global use of bind
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        //[BindProperty]    //more than 1 should be put individually
        public Benefit Benefit { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
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

        public async Task<IActionResult> OnPost()
        {
            var benefitFromDb = _unitOfWork.Benefit.GetFirstOrDefault(u => u.Id == Benefit.Id);
            if (benefitFromDb != null)
            {
                _unitOfWork.Benefit.Remove(benefitFromDb);
                _unitOfWork.Save();
				TempData["success"] = "Benefit deleted successfully";
				return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
