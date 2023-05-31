using Microsoft.AspNetCore.Mvc;
using MvcLibraryApp.Models.Entities;
using MvcLibraryApp.Repositories;
using MvcLibraryApp.ViewModels.Courses;

namespace MvcLibraryApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        private readonly CourseRepository _courseRepository;
        public CoursesController()
        {
            _courseRepository = new CourseRepository();
        }
        public IActionResult Index()
        {
            var course = _courseRepository.GetList();
            return View(course);
        }


        [HttpGet("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Add([FromForm] AddCourseViewModel model)
        {
            Course course = new()
            {
                LessonName = model.LessonName,
                LessonTime = model.LessonTime,
            };
            _courseRepository.Add(course);
            TempData["Message"] = "Record added successfully";
            return RedirectToAction("Index");
        }


        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var data = _courseRepository.Get(id);
             _courseRepository.Delete(data);
            return RedirectToAction("Index");
        }


        [HttpGet("[action]/{id}")]
        public ActionResult Update([FromRoute] int id)
        {
            var data = _courseRepository.Get(id);
            UpdateCourseViewModel model = new()
            {
                Id = id,
                LessonName = data.LessonName,
                LessonTime = data.LessonTime,
            };
            return View(model);
        }

        [HttpPost("[action]/{id}")]
        public ActionResult Update([FromForm] UpdateCourseViewModel model)
        {
            Course course = new()
            {
                Id = model.Id,
                LessonName = model.LessonName,
                LessonTime = model.LessonTime,
            };
            _courseRepository.Updated(course);
            return RedirectToAction("Index");

        }
    }
}
