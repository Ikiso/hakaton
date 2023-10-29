using Hackathon.Dtos;

namespace Hackathon.Services
{
    public interface ITestService
    {
        void EditItem(EditTestDto input);
        List<TestGetDto> GetAllLong(GetAllTestsDto input);
        List<TestGetItemShort> GetAllShort(GetAllTestsDto input);
        TestGetDto GetItemLong(int id);
        TestGetItemShort GetItemShort(int id);
        void DeleteItem(int id);
        int AddItem(AddTestDto input);
        bool IsExists(int id);
        bool AccessAllowedEmployee(int employeeId, int testId);
        bool AccessAllowedByCourseId(int employeeId, int courseId);
        TestResultDto SolutionTest(AttemptTestDto input, int employeeId);
        List<PassedTestsGetDto> GetPassedTests(int employeeId);
        List<PassedTestsGetDto> GetPassedByLastAttTests(int employeeId);
        List<TestGetItemInfo> GetAllWithAttInfo(GetAllTestsDto input, int employeeId);
    }
}
