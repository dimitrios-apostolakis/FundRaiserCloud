using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FundRaiserCloudWeb.Pages.User.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Project> ProjectList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

        public void OnGet()
        {
            ProjectList = _unitOfWork.Project.GetAll(includeProperties: "Category");
            CategoryList = _unitOfWork.Category.GetAll();
        }
    }
}
