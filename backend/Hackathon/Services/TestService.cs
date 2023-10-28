using Hackathon.Dtos;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services
{
    public class TestService : ITestService
    {
        private readonly ApplicationDbContext _context;
        public TestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void EditItem(EditTestDto input)
        {
            var test = _context.Tests.Find(input.Id)!;

            foreach (var q in input.Questions)
            {
                Question? question = _context.Questions.Find(q.Id);

                if (question == null)
                {
                    var added = _context.Questions.Add(new Question()
                    {
                        Content = q.Content,
                        Points = q.Points,
                    });
                    int addedId = added.Entity.Id;
                    _context.SaveChanges();

                    question = _context.Questions.Find(addedId)!;
                }
                else
                {
                    question.Content = q.Content;
                    question.Points = q.Points;
                }

                foreach (var o in q.Options)
                {
                    Option? option = _context.Options.Find(o.Id);
                    if (option == null)
                    {
                        _context.Options.Add(new Option()
                        {
                            IsCorrect = o.IsCorrect,
                            Name = o.Name,
                            Question = question
                        });
                    }
                    else
                    {
                        option.Name = o.Name;
                        option.IsCorrect = o.IsCorrect;
                    }
                }

                question!.Test = test;
            }

            test.Name = input.Name;
            test.Description = input.Description;
            test.StartDate = input.StartDate;
            test.EndDate = input.EndDate;

        }

        public List<TestGetDto> GetAllLong(GetAllTestsDto input)
        {
            List<TestGetDto> result = new();

            var tests = _context.Tests.Where(t => t.CourseId == input.CourseId);
            foreach (var test in tests)
            {
                result.Add(GetItemLong(test.Id));
            }

            return result;
        }

        public List<TestGetItemShort> GetAllShort(GetAllTestsDto input)
        {
            List<TestGetItemShort> result = new();

            var tests = _context.Tests.Where(t => t.CourseId == input.CourseId);
            foreach (var test in tests)
            {
                result.Add(GetItemShort(test.Id));
            }

            return result;
        }


        public TestGetDto GetItemLong(int id)
        {
            Test test = _context.Tests.Include(t => t.Questions).ThenInclude(q => q.Options).FirstOrDefault(t => t.Id == id)!;

            List<QuestionGetDto> questions = new();
            foreach (var q in test.Questions)
            {
                List<OptionGetDto> options = new();

                foreach (var o in q.Options)
                {
                    options.Add(new OptionGetDto(o.Id, o.Name, o.IsCorrect));
                }

                questions.Add(new QuestionGetDto()
                {
                    Content = q.Content,
                    Points = q.Points,
                    Options = options
                });
            }

            TestGetDto result = new()
            {
                Id = id,
                Description = test.Description,
                StartDate = test.StartDate,
                EndDate = test.EndDate,
                Name = test.Name,
                Questions = questions
            };

            return result;
        }

        public TestGetItemShort GetItemShort(int id)
        {
            Test test = _context.Tests.FirstOrDefault(t => t.Id == id)!;

            TestGetItemShort result = new()
            {
                Id = id,
                Description = test.Description,
                StartDate = test.StartDate,
                EndDate = test.EndDate,
                Name = test.Name
            };

            return result;
        }



        public void DeleteItem(int id)
        {
            var question = _context.Questions.Find(id)!;
            _context.Questions.Remove(question);
        }

        public int AddItem(AddTestDto input)
        {
            List<Question> questions = new List<Question>();

            foreach (var q in input.Questions)
            {
                List<Option> options = new();
                foreach (var o in q.Options)
                {
                    Option option = new Option()
                    {
                        IsCorrect = o.IsCorrect,
                        Name = o.Name
                    };

                    options.Add(option);
                    _context.Options.Add(option);
                }

                Question question = new Question()
                {
                    Content = q.Content,
                    Points = q.Points,
                    Options = options
                };

                questions.Add(question);
                _context.Questions.Add(question);
            }

            Test test = new Test()
            {
                Name = input.Name,
                Description = input.Description,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                Questions = questions

            };

            var result = _context.Tests.Add(test);
            _context.SaveChanges();

            return result.Entity.Id;
        }

        public bool IsExists(int id)
        {
            return _context.Tests.Find(id) != null;
        }
    }
}
