using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;
using Sieve.Services;

namespace IS.DZ03.Logic.Repositories
{
    public class UslugaRepository : GenericRepository<Usluga>, IUslugaRepository
    {
        public UslugaRepository(AutomobilskeUslugeContext context, ISieveProcessor processor) : base(context, processor)
        {
        }
    }
}
