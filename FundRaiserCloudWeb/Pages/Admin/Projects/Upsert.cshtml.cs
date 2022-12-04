using FundRaiser.DataAccess.Data;
using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FundRaiserCloudWeb.Pages.Admin.Projects
{
    [BindProperties]    //global use of bind
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        //[BindProperty]    //more than 1 should be put individually
        public Project Project { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            Project = new();
        }
        public void OnGet(int? id)
        {
			if (id != null)
			{
				//Edit
				Project = _unitOfWork.Project.GetFirstOrDefault(u => u.Id == id);
			}
			CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem()
			{
				Text = i.Name,
				Value = i.Id.ToString()
			});
		}

        public async Task<IActionResult> OnPost()
        {
			string webRootPath = _hostEnvironment.WebRootPath;
			var files = HttpContext.Request.Form.Files;
			if (Project.Id == 0)
			{
				//create
				string fileName_new = Guid.NewGuid().ToString();
				var uploads = Path.Combine(webRootPath, @"images\projectItems");
				var extension = Path.GetExtension(files[0].FileName);

				using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
				{
					files[0].CopyTo(fileStream);
				}
				Project.Image = @"\images\projectItems\" + fileName_new + extension;
				_unitOfWork.Project.Add(Project);
				_unitOfWork.Save();
			}
			else
			{
				//edit
			}

			return RedirectToPage("./Index");
		}
    }
}
