using Microsoft.AspNetCore.Mvc;
using MvcLibraryApp.Models.Entities;
using MvcLibraryApp.Repositories;
using MvcLibraryApp.ViewModels.Students;

namespace MvcLibraryApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly StudentRepository _studentRepository;
        public StudentsController()
        {
            _studentRepository = new StudentRepository();
        }
        public IActionResult Index()
        {
            var students = _studentRepository.GetList();
            return View(students);
        }

        [HttpGet("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Add([FromForm] AddStudentViewModel request)
        {
            Student student = new()
            {
                Name = request.Name,
                LastName = request.LastName,
                Language = request.Language,
                Number = request.Number,
            };
            _studentRepository.Add(student);
            return RedirectToAction("Index");
        }
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var student = _studentRepository.Get(id);
            _studentRepository.Delete(student);
            return RedirectToAction("Index");
        }
        [HttpGet("[action]/{id}")]
        public ActionResult Update([FromRoute] int id)
        {
            var data = _studentRepository.Get(id);
            UpdateStudentViewModel model = new() //mapping
            {
                Id = id,
                Name = data.Name,
                LastName = data.LastName,
                Language = data.Language,
                Number = data.Number
            };
            return View(model);
        }
        [HttpPost("[action]/{id}")]
        public ActionResult Update([FromForm] UpdateStudentViewModel request)
        {
            Student student = new()
            {
                Id = request.Id,
                Name = request.Name,
                LastName = request.LastName,
                Language = request.Language,
                Number = request.Number,
            };
            _studentRepository.Update(student);
            return RedirectToAction("Index");
        }
    }
}
