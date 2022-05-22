using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Repositories
{
    public class OsobaRepository : GenericRepository<Osoba>, IOsobaRepository
    {
        public OsobaRepository(AutomobilskeUslugeContext context, ISieveProcessor processor) : base(context, processor)
        {
        }

        public async Task<IEnumerable<Osoba>> GetEmployees(SieveModel model)
        {
            return await DatabaseContext.Set<Osoba>()
                .Include(o => o.Zaposlenik)
                .ToListAsync();
        }

        public async Task<IEnumerable<Osoba>> GetCustomerSupport()
        {
            return await DatabaseContext.Set<Osoba>()
                 .Include(o => o.KorisničkaSlužba)
                 .ToListAsync();
        }

        public async Task<Osoba> GetPersonByOIB(string oib)
        {
            return await DatabaseContext.Set<Osoba>()
                .Where(o => o.Oib == oib)
                .FirstOrDefaultAsync();
        }
    }
}
