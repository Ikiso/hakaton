using Hackathon.Dtos;
using Hackathon.Models;

namespace Hackathon.Services
{
    public interface ICourseService
    {
        public Course AddItem(CourseAddDto addCourse);
        public Course EditItem(CourseEditDto editCourse);
        public void DelteItem(GetCourseDto getCourse);
        public Course GetItem(GetCourseDto getCourse);

        public CourseDto GetItemDto(GetCourseDto getCourse);
        public List<CourseDto> GetItemDtoAll(GetDepartmentDto getDepartment);
    }
}
