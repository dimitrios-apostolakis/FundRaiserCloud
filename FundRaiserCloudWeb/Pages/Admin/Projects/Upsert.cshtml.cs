using FundRaiser.DataAccess.Data;
using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FundRaiserCloudWeb.Pages.Admin.Projects
{
    [BindProperties]    //global use of bind
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private UserManager<IdentityUser> UserManager;

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
                //Project.ProjectCreator = _unitOfWork.ProjectCreator.GetFirstOrDefault(a => a.UserName == UserManager.GetUserName(User));
                Project.ProjectCreator = _unitOfWork.ProjectCreator.GetFirstOrDefault(a => a.UserName == "alkis1@gmail.com");
                _unitOfWork.Project.Add(Project);
                _unitOfWork.Save();
			}
			else
			{
                //edit
                var objFromDb = _unitOfWork.Project.GetFirstOrDefault(u => u.Id == Project.Id);
                if (files.Count > 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\projectItems");
                    var extension = Path.GetExtension(files[0].FileName);

                    //delete the old image
                    var oldImagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                    //new upload
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    Project.Image = @"\images\projectItems\" + fileName_new + extension;
                }
                else
                {
                    Project.Image = objFromDb.Image;
                }
                _unitOfWork.Project.Update(Project);
                _unitOfWork.Save();
            }

			return RedirectToPage("./Index");
		}
    }
}
