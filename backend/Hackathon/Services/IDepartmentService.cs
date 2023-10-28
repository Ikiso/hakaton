using Hackathon.Dtos;
using Hackathon.Models;

namespace Hackathon.Services
{
    public interface IDepartmentService
    {
        public Department AddItem(DepartmentAddDto newDepartment);
        public Department EditItem(DepartmentEditDto departmentEdit);
        public DepartmentDto GetItem(GetDepartmentDto getDepartment);
        public Department ItemGet(int id);
        public List<DepartmentDto> GetAllItem(int OrganizationId);
        public DepartmentTreeDto GetTreeItem(GetDepartmentDto getDepartment);
        public void DeleteItem(GetDepartmentDto getDepartment);
        public bool ElementExists(GetDepartmentDto getDepartment);
    }
}
