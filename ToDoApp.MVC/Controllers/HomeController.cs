using Microsoft.AspNetCore.Mvc;
using ToDoApp.Business.Abstract;
using System.Threading.Tasks;

namespace ToDoApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        IWorkService _workService;

        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task<IActionResult> GetList()
        {
            var result = await _workService.GetAll();
            return View(result.Data);
        }

    }
}
