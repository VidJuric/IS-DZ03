using IS.DZ03.Model.Entities;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace IS.DZ03.Logic.Services.Sieves
{
    public class AutomobilskeUslugeSieveProcessor : SieveProcessor
    {
        public AutomobilskeUslugeSieveProcessor(IOptions<SieveOptions> options) : base(options) {}

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            _ = mapper.Property<Osoba>(o => o.Oib).CanFilter().CanSort();
            _ = mapper.Property<Osoba>(o => o.Ime).CanFilter().CanSort();
            _ = mapper.Property<Osoba>(o => o.Prezime).CanFilter().CanSort();
            _ = mapper.Property<Osoba>(o => o.Datumrodjenja).CanFilter().CanSort();
            _ = mapper.Property<Osoba>(o => o.Spol).CanFilter().CanSort();
            _ = mapper.Property<Osoba>(o => o.Datumzaposlenja).CanFilter().CanSort();
            _ = mapper.Property<Osoba>(o => o.Email).CanFilter().CanSort();

            return mapper;
        }
    }
}
