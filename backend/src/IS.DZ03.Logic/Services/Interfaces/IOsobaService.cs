using IS.DZ03.Model.Entities;
using Sieve.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services.Interfaces
{
    public interface IOsobaService
    {
        Task<IEnumerable<Osoba>> GetAllEmployees(SieveModel model);
    }
}
