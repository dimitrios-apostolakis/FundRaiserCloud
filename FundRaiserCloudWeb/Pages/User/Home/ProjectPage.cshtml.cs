using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FundRaiserCloudWeb.Pages.User.Home
{
    public class ProjectPageModel : PageModel
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public ProjectPageModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Project Project { get; set; }
        [Range(1, 100, ErrorMessage = "Please select a count between 1 and 100")]
        public int Count { get; set; }

        public void OnGet(int id)
        {
            Project = _unitOfWork.Project.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category");
        }
    }
}
