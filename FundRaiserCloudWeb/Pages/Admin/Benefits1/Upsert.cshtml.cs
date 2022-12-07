using FundRaiser.DataAccess.Data;
using FundRaiser.DataAccess.Repository.IRepository;
using FundRaiser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FundRaiserCloudWeb.Pages.Admin.Benefits1
{
    [BindProperties]    //global use of bind
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public Benefit Benefit { get; set; }
        public IEnumerable<SelectListItem> ProjectList { get; set; }
        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            Benefit = new();
        }
        public void OnGet(int? id)
        {
			if (id != null)
			{
                //Edit
                Benefit = _unitOfWork.Benefit.GetFirstOrDefault(u => u.Id == id);
			}
            ProjectList = _unitOfWork.Project.GetAll().Select(i => new SelectListItem()
			{
				Text = i.Title,
				Value = i.Id.ToString()
			});
		}

        public async Task<IActionResult> OnPost()
        {
			string webRootPath = _hostEnvironment.WebRootPath;
			var files = HttpContext.Request.Form.Files;
			if (Benefit.Id == 0)
			{
				//create
				string fileName_new = Guid.NewGuid().ToString();
				//var uploads = Path.Combine(webRootPath, @"images\projectItems");
				var extension = Path.GetExtension(files[0].FileName);

				//using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
				//{
				//	files[0].CopyTo(fileStream);
				//}
                
				_unitOfWork.Benefit.Add(Benefit);
				_unitOfWork.Save();
			}
			else
			{
                //edit
                var objFromDb = _unitOfWork.Project.GetFirstOrDefault(u => u.Id == Benefit.Id);
                if (files.Count > 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    //var uploads = Path.Combine(webRootPath, @"images\projectItems");
                    //var extension = Path.GetExtension(files[0].FileName);

                    //delete the old image
                    //var oldImagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                    //if (System.IO.File.Exists(oldImagePath))
                    //{
                    //    System.IO.File.Delete(oldImagePath);
                    //}
                    //new upload
                //    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                //    {
                //        files[0].CopyTo(fileStream);
                //    }
                //    Project.Image = @"\images\projectItems\" + fileName_new + extension;
                }
                //else
                //{
                //    Project.Image = objFromDb.Image;
                //}
                _unitOfWork.Benefit.Update(Benefit);
                _unitOfWork.Save();
            }

			return RedirectToPage("./Index");
		}
    }
}
