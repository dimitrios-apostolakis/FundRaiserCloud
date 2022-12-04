using FundRaiser.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FundRaiserCloudWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProjectController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Get()
		{
			var projectList = _unitOfWork.Project.GetAll(includeProperties: "Category");
			return Json(new { data = projectList });
		}
	}
}
