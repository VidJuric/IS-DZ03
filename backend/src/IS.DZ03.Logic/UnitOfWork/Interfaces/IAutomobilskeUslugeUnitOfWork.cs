using IS.DZ03.Logic.Repositories.Interfaces;
using System;

namespace IS.DZ03.Logic.UnitOfWork
{
    public interface IAutomobilskeUslugeUnitOfWork : IDisposable
    {
        IOsobaRepository Osoba { get; }
        IZadatakRepository Zadatak { get; }
        IStatusZadatkaRepository StatusZadatka { get; }
        IUslugaRepository Usluga { get; }
        IZaposlenikRepository Zaposlenik { get; }

        int Save();
    }
}
