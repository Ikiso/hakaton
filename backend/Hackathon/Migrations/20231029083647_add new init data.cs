using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Migrations
{
    public partial class addnewinitdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "DepartmentId", "Description", "Name" },
                values: new object[] { 1, 2, "Это курс про веб", "Веб-разработка" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "DepartmentId", "Description", "Name" },
                values: new object[] { 2, 2, "Это курс про тестирование", "Тестирование" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "DepartmentId", "Description", "Name" },
                values: new object[] { 3, 2, "Это курс про разработку игр", "Разработка игр" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 2);

            migrationBuilder.InsertData(
                table: "EducationalMaterials",
                columns: new[] { "Id", "Content", "ContentTypeId", "CourseId", "IsPublic" },
                values: new object[] { 1, "Веб-разработка это ...", 1, 1, true });

            migrationBuilder.InsertData(
                table: "EducationalMaterials",
                columns: new[] { "Id", "Content", "ContentTypeId", "CourseId", "IsPublic" },
                values: new object[] { 2, "https://www.youtube.com/watch?v=Ot1dBokdPFw", 3, 1, true });

            migrationBuilder.InsertData(
                table: "EducationalMaterials",
                columns: new[] { "Id", "Content", "ContentTypeId", "CourseId", "IsPublic" },
                values: new object[] { 3, "Итак мы поняли, что веб-разработка это ...", 1, 1, true });

            migrationBuilder.InsertData(
                table: "EducationalMaterials",
                columns: new[] { "Id", "Content", "ContentTypeId", "CourseId", "IsPublic" },
                values: new object[] { 4, "Тестирование это ...", 1, 2, true });

            migrationBuilder.InsertData(
                table: "EducationalMaterials",
                columns: new[] { "Id", "Content", "ContentTypeId", "CourseId", "IsPublic" },
                values: new object[] { 5, "https://www.youtube.com/watch?v=liirXTlmmRY", 3, 2, true });

            migrationBuilder.InsertData(
                table: "EducationalMaterials",
                columns: new[] { "Id", "Content", "ContentTypeId", "CourseId", "IsPublic" },
                values: new object[] { 6, "Итак мы поняли, что тестирование это ...", 1, 2, true });

            migrationBuilder.InsertData(
                table: "EducationalMaterials",
                columns: new[] { "Id", "Content", "ContentTypeId", "CourseId", "IsPublic" },
                values: new object[] { 7, "Разработка игр ...", 1, 3, true });

            migrationBuilder.InsertData(
                table: "EducationalMaterials",
                columns: new[] { "Id", "Content", "ContentTypeId", "CourseId", "IsPublic" },
                values: new object[] { 8, "https://www.youtube.com/watch?v=nRGOW9O7ARk", 3, 3, true });

            migrationBuilder.InsertData(
                table: "EducationalMaterials",
                columns: new[] { "Id", "Content", "ContentTypeId", "CourseId", "IsPublic" },
                values: new object[] { 9, "Итак мы поняли ...", 1, 3, true });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "CourseId", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 1, 1, "Тест по веб-разработке", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тест1", new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "CourseId", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 2, 2, "Тест по тестированию", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тест2", new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "CourseId", "Description", "EndDate", "Name", "StartDate" },
                values: new object[] { 3, 3, "Тест по рабработке игр", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тест3", new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PassedTests",
                columns: new[] { "Id", "AttemptNumber", "CompletionPercent", "EmployeeId", "IsOver", "TestId" },
                values: new object[] { 1, 1, 67.0, 2, true, 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 1, "Вопоос 1 ...", 1, 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 2, "Вопоос 2 ...", 1, 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 3, "Вопоос 3 ...", 1, 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 4, "Вопоос 4 ...", 1, 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 5, "Вопоос 1 ...", 1, 2 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 6, "Вопоос 2 ...", 1, 2 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 7, "Вопоос 3 ...", 1, 2 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 8, "Вопоос 4 ...", 1, 2 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 9, "Вопоос 1 ...", 1, 3 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 10, "Вопоос 2 ...", 1, 3 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 11, "Вопоос 3 ...", 1, 3 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "Points", "TestId" },
                values: new object[] { 12, "Вопоос 4 ...", 1, 3 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 1, false, "Пункт 1", 1 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 2, false, "Пункт 2", 1 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 3, false, "Пункт 3", 1 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 4, true, "Пункт 4", 1 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 5, false, "Пункт 1", 2 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 6, true, "Пункт 2", 2 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 7, false, "Пункт 3", 2 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 8, false, "Пункт 4", 2 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 9, false, "Пункт 1", 3 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 10, true, "Пункт 2", 3 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 11, false, "Пункт 1", 4 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 12, true, "Пункт 2", 4 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 13, false, "Пункт 1", 5 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 14, true, "Пункт 2", 5 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 15, false, "Пункт 1", 6 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 16, true, "Пункт 2", 6 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 17, false, "Пункт 1", 7 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 18, true, "Пункт 2", 7 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 19, false, "Пункт 1", 8 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 20, true, "Пункт 2", 8 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 21, false, "Пункт 1", 9 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 22, true, "Пункт 2", 9 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 23, false, "Пункт 1", 10 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 24, true, "Пункт 2", 10 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 25, false, "Пункт 1", 11 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 26, true, "Пункт 2", 11 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 27, false, "Пункт 1", 12 });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "Name", "QuestionId" },
                values: new object[] { 28, true, "Пункт 2", 12 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EducationalMaterials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EducationalMaterials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EducationalMaterials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EducationalMaterials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EducationalMaterials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EducationalMaterials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EducationalMaterials",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EducationalMaterials",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EducationalMaterials",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PassedTests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 1);
        }
    }
}
