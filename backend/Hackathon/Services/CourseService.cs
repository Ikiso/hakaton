using Hackathon.Dtos;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Hackathon.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Course AddItem(CourseAddDto addCourse)
        {
            var course = new Course()
            {
                Name = addCourse.Name,
                Description = addCourse.Description,
                Department = _context.Departments.Find(addCourse.DepartmentId)!
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public void DelteItem(GetCourseDto getCourse)
        {
            _context.Courses.Remove(_context.Courses.Find(getCourse.Id)!);
            _context.SaveChanges();
        }

        public Course EditItem(CourseEditDto editCourse)
        {
            var course = _context.Courses.FirstOrDefault(a => a.Id == editCourse.Id)!;
            course.Description = editCourse.Description;
            course.Department = _context.Departments.Find(editCourse.DepartmentId)!;
            course.Name = editCourse.Name;
            _context.Courses.Update(course);
            _context.SaveChanges();
            return course;
        }

        public Course GetItem(GetCourseDto getCourse)
        {
            return _context.Courses.Include(a => a.Department).Include(a => a.EducationalMaterials).FirstOrDefault(a => a.Id == getCourse.Id)!;
        }

        public CourseDto GetItemDto(GetCourseDto getCourse)
        {
            var course = _context.Courses.FirstOrDefault(a => a.Id == getCourse.Id)!;
            var courseDto = new CourseDto(course.Id, course.Name, course.Description, course.DepartmentId);
            
            return courseDto;
        }

        public List<CourseDto> GetItemDtoAll(int DepartmentId)
        {
            var result = new List<CourseDto>();
            foreach (var course in _context.Courses.Where(a=>a.DepartmentId == DepartmentId).ToList())
            {
                result.Add(new CourseDto(course.Id, course.Name, course.Description, course.DepartmentId));
            }
            return result;
        }
    }
}
