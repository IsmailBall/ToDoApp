using Microsoft.AspNetCore.Mvc;
using ToDoApp.Business.Abstract;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ToDoApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        IWorkService _workService;

        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> GetList(string url)
        {
            var result = await _workService.GetAll();
            //var x = User.Identity.Name;
            //var y = HttpContext.User.Identity.Name;
            return View(result.Data);
        }

    }
}
