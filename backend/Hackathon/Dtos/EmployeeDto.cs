namespace Hackathon.Dtos
{

   
        public record class EmployeeEditDto(int id, string Post, int RoleId, int StatusId, int DepartmentId);
        public record class EmployeeGetDto(int id, string Firstname, string Surname, string Patonymic, string Post, int RoleId, int StatusId, int DepartmentId);
  
}
