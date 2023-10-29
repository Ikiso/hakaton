using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Migrations
{
    public partial class inittest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Email", "PasswordHash" },
                values: new object[] { 1, "myemail@mail.com", "A02CB78D91D3079A6D245A45FDBEC9472C25C323" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Email", "PasswordHash" },
                values: new object[] { 2, "myemail2@mail.com", "B12D0A0F9688163B3A744B87A2340904018986D7" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address", "ColorId", "Description", "Goal", "Inn", "Mission", "Name", "TariffId" },
                values: new object[] { 1, "Орловская область, город Люберцы, въезд Бухарестская, 34", 1, null, null, "1231231321231", null, "Technopoint", 1 });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address", "ColorId", "Description", "Goal", "Inn", "Mission", "Name", "TariffId" },
                values: new object[] { 2, "Новгородская область, город Можайск, пер. Будапештсткая, 79", 1, null, null, "234324324234", null, "JustOrganization", 1 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentId", "Name", "OrganizationId" },
                values: new object[] { 1, null, "HR ", 1 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentId", "Name", "OrganizationId" },
                values: new object[] { 2, null, "IT ", 1 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentId", "Name", "OrganizationId" },
                values: new object[] { 3, null, "IT ", 2 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentId", "Name", "OrganizationId" },
                values: new object[] { 4, null, "HR ", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "DateOfBirdh", "Firstname", "Patronymic", "Surname", "TelegramUsername" },
                values: new object[] { 1, 1, new DateOnly(2000, 2, 23), "Глеб", "Артемович", "Рогов", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "DateOfBirdh", "Firstname", "Patronymic", "Surname", "TelegramUsername" },
                values: new object[] { 2, 2, new DateOnly(1998, 2, 23), "Иванов", "Максимович", "Артем", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Post", "RoleId", "StatusId", "UserId" },
                values: new object[] { 1, 2, null, 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Post", "RoleId", "StatusId", "UserId" },
                values: new object[] { 2, 2, null, 4, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
