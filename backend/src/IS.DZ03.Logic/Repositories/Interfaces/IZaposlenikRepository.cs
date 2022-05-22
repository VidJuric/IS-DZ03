using IS.DZ03.Model.Entities;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Repositories.Interfaces
{
    public interface IZaposlenikRepository : IGenericRepository<Zaposlenik>
    {
        Task<Zaposlenik> GetEmployeeByOIB(string oib);
    }
}
