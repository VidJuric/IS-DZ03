using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;
using Sieve.Models;
using Sieve.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Repositories
{
    public class OsobaRepository : GenericRepository<Osoba>, IOsobaRepository
    {
        public OsobaRepository(AutomobilskeUslugeContext context, ISieveProcessor processor) : base(context, processor)
        {
        }

        public async Task<IEnumerable<Osoba>> GetEmployees(SieveModel model) => await GetAll(model);
    }
}
