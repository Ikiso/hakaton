using Hackathon.Dtos;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Department AddItem(DepartmentAddDto newDepartment)
        {
            var department = new Department()
            {
                Name = newDepartment.Name,
                Organization = _context.Organizations.FirstOrDefault(a=>a.Id == newDepartment.DepartmentId)!
            };
            _context.Add(department);
            return department;
        }

        public void DeleteItem(GetDepartmentDto getDepartment)
        {
            var departament = _context.Departments.Find(getDepartment.Id)!;
            _context.Remove(departament);
            _context.SaveChanges();
        }

        public Department EditItem(DepartmentEditDto departmentEdit)
        {
            var departament = _context.Departments.Find(departmentEdit.Id)!;
            departament.Name = departmentEdit.Name;
            _context.Update(departament);
            _context.SaveChanges();
            return departament;

        }

        public bool ElementExists(GetDepartmentDto getDepartment)
        {
            return _context.Departments.Find(getDepartment.Id) != null;
        }

        public List<DepartmentDto> GetAllItem()
        {
            var result = new List<DepartmentDto>();
            foreach (var item in _context.Departments.ToList())
            {
                result.Add(new DepartmentDto() { Id = item.Id, Name = item.Name });
            }
            return result;
        }

        public DepartmentDto GetItem(GetOrganizationDto getOrganization)
        {
            var result = new DepartmentDto();
            var departnent = _context.Departments.Find(getOrganization.Id)!;
            result.Name = departnent.Name;
            result.Id = departnent.Id;
            return result;
        }

        public DepartmentTreeDto GetTreeItem(GetDepartmentDto getDepartment)
        {
            return GetChildDepartment(_context.Departments.Include(a => a.ChildDepartment).FirstOrDefault(a => a.Id == getDepartment.Id)!);
        }

        private DepartmentTreeDto GetChildDepartment(Department department)
        {
            DepartmentTreeDto result = new DepartmentTreeDto();
            department = _context.Departments.Include(a => a.ChildDepartment).FirstOrDefault(a => a.Id == department.Id)!;
            result.Name = department.Name;

            foreach (var item in department.ChildDepartment)
            {
                result.ChildDepartment.Add(GetChildDepartment(item));
            }

            return result;
        }
    }
}
