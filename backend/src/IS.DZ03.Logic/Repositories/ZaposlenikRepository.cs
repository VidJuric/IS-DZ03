using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using System.Linq;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Repositories
{
    public class ZaposlenikRepository : GenericRepository<Zaposlenik>, IZaposlenikRepository
    {
        public ZaposlenikRepository(AutomobilskeUslugeContext context, ISieveProcessor processor) : base(context, processor)
        {
        }

        public async Task<Zaposlenik> GetEmployeeByOIB(string oib)
        {
            return await DatabaseContext.Set<Zaposlenik>()
                .Where(o => o.Oib == oib)
                .FirstOrDefaultAsync();
        }
    }
}
