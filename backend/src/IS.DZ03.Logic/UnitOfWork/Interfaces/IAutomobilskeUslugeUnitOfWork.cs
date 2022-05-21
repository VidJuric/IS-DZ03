using IS.DZ03.Logic.Repositories.Interfaces;
using System;

namespace IS.DZ03.Logic.UnitOfWork
{
    public interface IAutomobilskeUslugeUnitOfWork : IDisposable
    {
        IOsobaRepository Osoba { get; }
        int Save();
    }
}
