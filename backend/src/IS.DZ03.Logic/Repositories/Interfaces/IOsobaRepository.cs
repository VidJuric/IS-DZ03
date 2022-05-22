using IS.DZ03.Model.Entities;
using Sieve.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Repositories.Interfaces
{
    public interface IOsobaRepository : IGenericRepository<Osoba>
    {
        Task<IEnumerable<Osoba>> GetEmployees(SieveModel model);

        Task<IEnumerable<Osoba>> GetCustomerSupport();
    }
}
