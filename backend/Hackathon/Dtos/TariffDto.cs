namespace Hackathon.Dtos
{
    public record class TariffDto(int Id, string Name, string Decription, int Price, int EmployeeLimit);
    public record class TariffGet(int Id);
    public record class TariffEdit(int Id, string Name, string Decription, int Price, int EmployeeLimit);
    public record class TariffAdd(string Name, string Decription, int Price, int EmployeeLimit);

}
