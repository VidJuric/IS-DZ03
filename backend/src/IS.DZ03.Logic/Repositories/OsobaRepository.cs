using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;

namespace IS.DZ03.Logic.Repositories
{
    public class OsobaRepository : GenericRepository<Osoba>, IOsobaRepository
    {
        public OsobaRepository(AutomobilskeUslugeContext context) : base(context) { }
    }
}
