using Microsoft.EntityFrameworkCore;

namespace Hackathon.Models
{
    public class InitializeDb
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            // Роли
            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "superadmin" },
                new Role() { Id = 2, Name = "admin" },
                new Role() { Id = 3, Name = "hr" },
                new Role() { Id = 4, Name = "user" }
                );

            // Цвета
            modelBuilder.Entity<Color>().HasData(
                new Color() { Id = 1, Name = "default" }
                );

            // Статус работника
            modelBuilder.Entity<Status>().HasData(
                new Role() { Id = 1, Name = "работает" },
                new Role() { Id = 2, Name = "в отпуске" },
                new Role() { Id = 3, Name = "в командировке" },
                new Role() { Id = 4, Name = "уволен" }
                );

            // Тип контента
            modelBuilder.Entity<ContentType>().HasData(
               new Role() { Id = 1, Name = "текст" },
               new Role() { Id = 2, Name = "иллюстрация" },
               new Role() { Id = 3, Name = "видео" },
               new Role() { Id = 4, Name = "ссылка на учебный материал" }
               );

            // Тарифы
            modelBuilder.Entity<Tariff>().HasData(
               new Tariff() { Id = 1, Name = "бесплатный", EmployeeLimit = 5, Decription = "Тариф для личного пользования и  небольших компаний", Price = 0 },
               new Tariff() { Id = 2, Name = "малый бизнес", EmployeeLimit = 50, Decription = "Тариф для ИП и малого бизнеса", Price = 5000 },
               new Tariff() { Id = 3, Name = "средний", EmployeeLimit = 500, Decription = "Тариф для средних предприятий", Price = 10000 },
               new Tariff() { Id = 4, Name = "корпорация", EmployeeLimit = -1, Decription = "Тариф для копораций без лимита по пользователям", Price = 100000 }
               );

            // Аккаунт
            modelBuilder.Entity<Account>().HasData(
                new Account() { Id = 1, Email = "myemail@mail.com", PasswordHash = "A02CB78D91D3079A6D245A45FDBEC9472C25C323" }, // R8O7krWjK
                new Account() { Id = 2, Email = "myemail2@mail.com", PasswordHash = "B12D0A0F9688163B3A744B87A2340904018986D7" } // vl64lvXfg
                );

            // Пользователь
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, AccountId = 1, DateOfBirdh = new DateOnly(2000, 2, 23), Firstname = "Глеб", Surname = "Рогов", Patronymic = "Артемович" },
                new User() { Id = 2, AccountId = 2, DateOfBirdh = new DateOnly(1998, 2, 23), Firstname = "Иванов", Surname = "Артем", Patronymic = "Максимович" }
                );

            // Организация
            modelBuilder.Entity<Organization>().HasData(
                new Organization() { Id = 1, Name = "Technopoint", ColorId = 1, TariffId = 1, Inn = "1231231321231", Address = "Орловская область, город Люберцы, въезд Бухарестская, 34" },
                new Organization() { Id = 2, Name = "JustOrganization", ColorId = 1, TariffId = 1, Inn = "234324324234", Address = "Новгородская область, город Можайск, пер. Будапештсткая, 79" }
                );

            // Подразделение
            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 1, Name = "HR ", OrganizationId = 1 },
                new Department() { Id = 2, Name = "IT ", OrganizationId = 1 },
                new Department() { Id = 3, Name = "IT ", OrganizationId = 2 },
                new Department() { Id = 4, Name = "HR ", OrganizationId = 2 }
                );

            // Сотрудник
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, DepartmentId = 2, RoleId = 2, UserId = 1, StatusId = 1 },
                new Employee() { Id = 2, DepartmentId = 2, RoleId = 4, UserId = 2, StatusId = 1 }
                );

            // Курс
            modelBuilder.Entity<Course>().HasData(
                new Course() { Id = 1, DepartmentId = 2, Description = "Это курс про веб", Name = "Веб-разработка" },
                new Course() { Id = 2, DepartmentId = 2, Description = "Это курс про тестирование", Name = "Тестирование" },
                new Course() { Id = 3, DepartmentId = 2, Description = "Это курс про разработку игр", Name = "Разработка игр" });

            // Обучающий материал
            modelBuilder.Entity<EducationalMaterial>().HasData(
                new EducationalMaterial() { Id = 1, CourseId = 1, IsPublic = true, Content = "Веб-разработка это ...", ContentTypeId = 1 },
                new EducationalMaterial() { Id = 2, CourseId = 1, IsPublic = true, Content = "https://www.youtube.com/watch?v=Ot1dBokdPFw", ContentTypeId = 3 },
                new EducationalMaterial() { Id = 3, CourseId = 1, IsPublic = true, Content = "Итак мы поняли, что веб-разработка это ...", ContentTypeId = 1 },

                new EducationalMaterial() { Id = 4, CourseId = 2, IsPublic = true, Content = "Тестирование это ...", ContentTypeId = 1 },
                new EducationalMaterial() { Id = 5, CourseId = 2, IsPublic = true, Content = "https://www.youtube.com/watch?v=liirXTlmmRY", ContentTypeId = 3 },
                new EducationalMaterial() { Id = 6, CourseId = 2, IsPublic = true, Content = "Итак мы поняли, что тестирование это ...", ContentTypeId = 1 },

                new EducationalMaterial() { Id = 7, CourseId = 3, IsPublic = true, Content = "Разработка игр ...", ContentTypeId = 1 },
                new EducationalMaterial() { Id = 8, CourseId = 3, IsPublic = true, Content = "https://www.youtube.com/watch?v=nRGOW9O7ARk", ContentTypeId = 3 },
                new EducationalMaterial() { Id = 9, CourseId = 3, IsPublic = true, Content = "Итак мы поняли ...", ContentTypeId = 1 }
                );

            // Тест
            modelBuilder.Entity<Test>().HasData(
                new Test() { Id = 1, Name = "Тест1", CourseId = 1, StartDate = new DateTime(2023,10,28), EndDate = new DateTime(2023, 10, 30), Description = "Тест по веб-разработке"},
                new Test() { Id = 2, Name = "Тест2", CourseId = 2, StartDate = new DateTime(2023,10,28), EndDate = new DateTime(2023, 10, 30), Description = "Тест по тестированию" },
                new Test() { Id = 3, Name = "Тест3", CourseId = 3, StartDate = new DateTime(2023,10,28), EndDate = new DateTime(2023, 10, 30), Description = "Тест по рабработке игр"}
                );

            // Вопрос
            modelBuilder.Entity<Question>().HasData(
                    new Question() { Id = 1, Content = "Вопоос 1 ...", Points = 1, TestId = 1},
                    new Question() { Id = 2, Content = "Вопоос 2 ...", Points = 1, TestId = 1},
                    new Question() { Id = 3, Content = "Вопоос 3 ...", Points = 1, TestId = 1},
                    new Question() { Id = 4, Content = "Вопоос 4 ...", Points = 1, TestId = 1},

                    new Question() { Id = 5, Content = "Вопоос 1 ...", Points = 1, TestId = 2 },
                    new Question() { Id = 6, Content = "Вопоос 2 ...", Points = 1, TestId = 2 },
                    new Question() { Id = 7, Content = "Вопоос 3 ...", Points = 1, TestId = 2 },
                    new Question() { Id = 8, Content = "Вопоос 4 ...", Points = 1, TestId = 2 },

                    new Question() { Id = 9, Content = "Вопоос 1 ...", Points = 1, TestId = 3 },
                    new Question() { Id = 10, Content = "Вопоос 2 ...", Points = 1, TestId = 3 },
                    new Question() { Id = 11, Content = "Вопоос 3 ...", Points = 1, TestId = 3 },
                    new Question() { Id = 12, Content = "Вопоос 4 ...", Points = 1, TestId = 3 }
                );

            // Варинт ответа
            modelBuilder.Entity<Option>().HasData(
                new Option() { Id = 1, Name = "Пункт 1", IsCorrect = false, QuestionId = 1},
                new Option() { Id = 2, Name = "Пункт 2", IsCorrect = false, QuestionId = 1},
                new Option() { Id = 3, Name = "Пункт 3", IsCorrect = false, QuestionId = 1},
                new Option() { Id = 4, Name = "Пункт 4", IsCorrect = true, QuestionId = 1},

                new Option() { Id = 5, Name = "Пункт 1", IsCorrect = false, QuestionId = 2 },
                new Option() { Id = 6, Name = "Пункт 2", IsCorrect = true, QuestionId = 2 },
                new Option() { Id = 7, Name = "Пункт 3", IsCorrect = false, QuestionId = 2 },
                new Option() { Id = 8, Name = "Пункт 4", IsCorrect = false, QuestionId = 2 },

                new Option() { Id = 9, Name = "Пункт 1", IsCorrect = false, QuestionId = 3 },
                new Option() { Id = 10, Name = "Пункт 2", IsCorrect = true, QuestionId = 3 },

                new Option() { Id = 11, Name = "Пункт 1", IsCorrect = false, QuestionId = 4 },
                new Option() { Id = 12, Name = "Пункт 2", IsCorrect = true, QuestionId = 4 },

                new Option() { Id = 13, Name = "Пункт 1", IsCorrect = false, QuestionId = 5 },
                new Option() { Id = 14, Name = "Пункт 2", IsCorrect = true, QuestionId = 5 },

                new Option() { Id = 15, Name = "Пункт 1", IsCorrect = false, QuestionId = 6 },
                new Option() { Id = 16, Name = "Пункт 2", IsCorrect = true, QuestionId = 6 },

                new Option() { Id = 17, Name = "Пункт 1", IsCorrect = false, QuestionId = 7 },
                new Option() { Id = 18, Name = "Пункт 2", IsCorrect = true, QuestionId = 7 },

                new Option() { Id = 19, Name = "Пункт 1", IsCorrect = false, QuestionId = 8 },
                new Option() { Id = 20, Name = "Пункт 2", IsCorrect = true, QuestionId = 8 },

                new Option() { Id = 21, Name = "Пункт 1", IsCorrect = false, QuestionId = 9 },
                new Option() { Id = 22, Name = "Пункт 2", IsCorrect = true, QuestionId = 9 },

                new Option() { Id = 23, Name = "Пункт 1", IsCorrect = false, QuestionId = 10 },
                new Option() { Id = 24, Name = "Пункт 2", IsCorrect = true, QuestionId = 10 },

                new Option() { Id = 25, Name = "Пункт 1", IsCorrect = false, QuestionId = 11 },
                new Option() { Id = 26, Name = "Пункт 2", IsCorrect = true, QuestionId = 11 },

                new Option() { Id = 27, Name = "Пункт 1", IsCorrect = false, QuestionId = 12 },
                new Option() { Id = 28, Name = "Пункт 2", IsCorrect = true, QuestionId = 12 }
                );

            // Пройденные тесты
            modelBuilder.Entity<PassedTests>().HasData(
                new PassedTests() { Id = 1, EmployeeId = 2, TestId = 1, AttemptNumber = 1, CompletionPercent = 67, IsOver = true }
                );

        }
    }
}
