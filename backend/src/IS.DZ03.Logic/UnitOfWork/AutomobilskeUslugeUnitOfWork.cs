using IS.DZ03.Logic.Repositories;
using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;
using Sieve.Services;
using System;

namespace IS.DZ03.Logic.UnitOfWork
{
    public class AutomobilskeUslugeUnitOfWork : IAutomobilskeUslugeUnitOfWork
    {
        private readonly AutomobilskeUslugeContext _context;
        private readonly ISieveProcessor _processor;

        private IOsobaRepository _osobaRepository;
        private IZadatakRepository _zadatakRepository;
        private IStatusZadatkaRepository _statusZadatkaRepository;
        private IUslugaRepository _uslugaRepository;

        public AutomobilskeUslugeUnitOfWork(AutomobilskeUslugeContext context, ISieveProcessor processor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
            _processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        public IOsobaRepository Osoba
        {
            get
            {
                if (_osobaRepository is null)
                {
                    _osobaRepository = new OsobaRepository(_context, _processor);
                }

                return _osobaRepository;
            }
        }

        public IZadatakRepository Zadatak
        {
            get
            {
                if (_zadatakRepository is null)
                {
                    _zadatakRepository = new ZadatakRepository(_context, _processor);
                }

                return _zadatakRepository;
            }
        }

        public IStatusZadatkaRepository StatusZadatka
        {
            get
            {
                if (_statusZadatkaRepository is null)
                {
                    _statusZadatkaRepository = new StatusZadatkaRepository(_context, _processor);
                }

                return _statusZadatkaRepository;
            }
        }

        public IUslugaRepository Usluga
        {
            get
            {
                if (_uslugaRepository is null)
                {
                    _uslugaRepository = new UslugaRepository(_context, _processor);
                }

                return _uslugaRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
