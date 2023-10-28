using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Migrations
{
    public partial class erte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_ChildDepartmentId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Organizations_OrganizationId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "ChildDepartmentId",
                table: "Departments",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_ChildDepartmentId",
                table: "Departments",
                newName: "IX_Departments_DepartmentId");

            migrationBuilder.AddColumn<double>(
                name: "CompletionPercent",
                table: "PassedTests",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOver",
                table: "PassedTests",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "EducationalMaterials",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "Departments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "default" });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "Decription", "EmployeeLimit", "Name", "Price" },
                values: new object[] { 1, "Тариф для личного пользования и  небольших компаний", 5, "бесплатный", 0 });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "Decription", "EmployeeLimit", "Name", "Price" },
                values: new object[] { 2, "Тариф для ИП и малого бизнеса", 50, "малый бизнес", 5000 });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "Decription", "EmployeeLimit", "Name", "Price" },
                values: new object[] { 3, "Тариф для средних предприятий", 500, "средний", 10000 });

            migrationBuilder.InsertData(
                table: "Tariffs",
                columns: new[] { "Id", "Decription", "EmployeeLimit", "Name", "Price" },
                values: new object[] { 4, "Тариф для копораций без лимита по пользователям", -1, "корпорация", 100000 });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_DepartmentId",
                table: "Departments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Organizations_OrganizationId",
                table: "Departments",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_DepartmentId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Organizations_OrganizationId",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tariffs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CompletionPercent",
                table: "PassedTests");

            migrationBuilder.DropColumn(
                name: "IsOver",
                table: "PassedTests");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "EducationalMaterials");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Departments",
                newName: "ChildDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_DepartmentId",
                table: "Departments",
                newName: "IX_Departments_ChildDepartmentId");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "Departments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_ChildDepartmentId",
                table: "Departments",
                column: "ChildDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Organizations_OrganizationId",
                table: "Departments",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }
    }
}
