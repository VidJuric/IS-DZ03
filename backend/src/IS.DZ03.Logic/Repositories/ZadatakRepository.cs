using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Repositories
{
    public class ZadatakRepository : GenericRepository<Zadatak>, IZadatakRepository
    {
        public ZadatakRepository(AutomobilskeUslugeContext context, ISieveProcessor processor) : base(context, processor)
        {
        }

        public async Task<IList<Zadatak>> GetEmployeeTasks(long employeeID)
        {
            return await DatabaseContext.Set<Zadatak>()
                .Where(z => z.Zaposlenikid == employeeID)
                .ToListAsync();
        }
    }
}
