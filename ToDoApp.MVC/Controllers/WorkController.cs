using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApp.Business.Abstract;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.MVC.Controllers
{
    public class WorkController : Controller
    {
        IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }
        [Authorize]
        public IActionResult Add()
        {
            return View(new Work());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Work work)
        {
            
            await _workService.Add(work);
            return RedirectToAction("GetList","Home");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var deletedWorkResult = await _workService.Get(id);
            if (deletedWorkResult.IsSucceed)
            {
                await _workService.Remove(deletedWorkResult.Data);
            }
            return RedirectToAction("GetList","Home");
        }
        [Authorize]
        public async Task<IActionResult> Update(int id)
        {
            var updatedWorkResult = await _workService.Get(id);
            if (updatedWorkResult.IsSucceed)
            {
                return View(updatedWorkResult.Data);
            }
            return RedirectToAction("GetList", "Home");
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(Work work)
        {

            await _workService.Update(work);
            return RedirectToAction("GetList", "Home");
        }
    }
}
