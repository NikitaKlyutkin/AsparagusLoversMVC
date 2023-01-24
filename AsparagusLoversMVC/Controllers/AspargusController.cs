using System;
using System.Linq;
using System.Threading.Tasks;
using AsparagusLoversMVC.Database.Entityes;
using AsparagusLoversMVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace AsparagusLoversMVC.Controllers
{
	[Controller]

	[Route("[controller]/[action]")]
	public class AspargusController : Controller
	{
		
		private readonly ServiceApp _service;

		public AspargusController(ServiceApp service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Asparagus asparagus)
		{
			
			await _service.Create(asparagus);
			return View();
		}

        [HttpGet]
        public IActionResult GetAspargus()
        {
            return View(_service.GetAsparagus().ToList());
        }
	}
}
