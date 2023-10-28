using Hackathon.Dtos;
using Hackathon.Models;

namespace Hackathon.Services
{
    public interface ITariffService
    {
        public List<TariffDto> GetAll(); 
        public Tariff GetItem(int id);
        public TariffDto GetItemDto(TariffGet tariffGet);
        public Tariff AddItem(TariffAdd tariffAdd);
        public Tariff EditItem(TariffEdit tariffEdit);
        public void RemoveItem(TariffGet tariffGet);


    }
}
