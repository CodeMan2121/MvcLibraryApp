using Microsoft.AspNetCore.Mvc;
using MvcLibraryApp.Models.Entities;
using MvcLibraryApp.Repositories;
using MvcLibraryApp.ViewModels.Students;
using MvcLibraryApp.ViewModels.Teachers;

namespace MvcLibraryApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : Controller
    {
        private readonly TeacherRepository _teacherRepository;
        public TeachersController()
        {
            _teacherRepository = new TeacherRepository();
        }
        public IActionResult Index()
        {
            var teacher = _teacherRepository.GetList();
            return View(teacher);
        }

        [HttpGet("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Add([FromForm] AddTeacherViewModel request)
        {
            Teacher teacher = new()
            {
                Name = request.Name,
                LastName = request.LastName,
                ExperienceYear = request.ExperienceYear,
            };
            _teacherRepository.Add(teacher);
            return RedirectToAction("Index");
        }
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var teacher = _teacherRepository.Get(id);
            _teacherRepository.Delete(teacher);
            return RedirectToAction("Index");
        }
        [HttpGet("[action]/{id}")]
        public ActionResult Update([FromRoute] int id)
        {
            var data = _teacherRepository.Get(id);
            UpdateTeacherViewModel model = new() //mapping
            {
                Id = id,
                Name = data.Name,
                LastName = data.LastName,
                ExperienceYear = data.ExperienceYear
            };
            return View(model);
        }
        [HttpPost("[action]/{id}")]
        public ActionResult Update([FromForm] UpdateTeacherViewModel request)
        {
            Teacher teacher = new()
            {
                Id = request.Id,
                Name = request.Name,
                LastName = request.LastName,
                ExperienceYear = request.ExperienceYear,
            };
            _teacherRepository.Update(teacher);
            return RedirectToAction("Index");
        }

    }
}
