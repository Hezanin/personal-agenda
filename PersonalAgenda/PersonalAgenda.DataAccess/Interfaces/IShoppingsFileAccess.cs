using PersonalAgenda.Domain.Entities;

namespace PersonalAgenda.DataAccess.Interfaces
{
    public interface IShoppingsFileAccess
    {
        void AddShopping(Shopping newShopping);
        IEnumerable<Shopping> LoadShoppings();
    }
}