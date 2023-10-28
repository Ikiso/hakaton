using Hackathon.Dtos;
using Hackathon.Models;

namespace Hackathon.Services
{
    public interface IDepartmentService
    {
        public Department AddItem(DepartmentAddDto newDepartment);
        public Department EditItem(DepartmentEditDto departmentEdit);
        public DepartmentDto GetItem(GetOrganizationDto getOrganization);
        public List<DepartmentDto> GetAllItem();
        public DepartmentTreeDto GetTreeItem(GetDepartmentDto getDepartment);
        public void DeleteItem(GetDepartmentDto getDepartment);
        public bool ElementExists(GetDepartmentDto getDepartment);
    }
}
