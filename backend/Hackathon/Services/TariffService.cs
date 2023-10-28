using Hackathon.Dtos;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Services
{
    public class TariffService : ITariffService
    {
        private readonly ApplicationDbContext _context;
        public TariffService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Tariff AddItem(TariffAdd tariffAdd)
        {
            var tariff = new Tariff()
            {
                Decription = tariffAdd.Decription,
                EmployeeLimit = tariffAdd.EmployeeLimit,
                Name = tariffAdd.Name,
                Price = tariffAdd.Price
            };
            _context.Tariffs.Add(tariff);
            _context.SaveChanges();
            return tariff;
        }

        public Tariff EditItem(TariffEdit tariffEdit)
        {
            var tariff = _context.Tariffs.FirstOrDefault(a => a.Id == tariffEdit.Id)!;
            tariff.Price = tariffEdit.Price;
            tariff.EmployeeLimit = tariffEdit.EmployeeLimit;
            tariff.Decription = tariffEdit.Decription;
            tariff.Name = tariffEdit.Name;

            _context.Tariffs.Update(tariff);
            _context.SaveChanges();
            return tariff;
        }

        public List<TariffDto> GetAll()
        {
            var result = new List<TariffDto>();
            foreach (var item in _context.Tariffs.ToList())
            {
                result.Add(new TariffDto(item.Id, item.Name, item.Decription, item.Price, item.EmployeeLimit));
            }
            return result;
        }

        public Tariff GetItem(int id)
        {
            return _context.Tariffs.Include(a => a.Organizations).FirstOrDefault(a => a.Id == id)!;
        }

        public TariffDto GetItemDto(TariffGet tariffGet)
        {
            var tariff = GetItem(tariffGet.Id);
            return new TariffDto(tariff.Id, tariff.Name, tariff.Decription, tariff.Price, tariff.EmployeeLimit);
        }

        public void RemoveItem(TariffGet tariffGet)
        {
            var tariff = GetItem(tariffGet.Id);
            _context.Tariffs.Remove(tariff);
            _context.SaveChanges();
        }
    }
}
