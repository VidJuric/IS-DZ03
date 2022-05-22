using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;
using Sieve.Services;

namespace IS.DZ03.Logic.Repositories
{
    public class ZaposlenikRepository : GenericRepository<Zaposlenik>, IZaposlenikRepository
    {
        public ZaposlenikRepository(AutomobilskeUslugeContext context, ISieveProcessor processor) : base(context, processor)
        {
        }
    }
}
