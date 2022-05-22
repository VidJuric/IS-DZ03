using IS.DZ03.Logic.Repositories;
using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.UnitOfWork
{
    public class AutomobilskeUslugeUnitOfWork : IAutomobilskeUslugeUnitOfWork
    {
        private readonly AutomobilskeUslugeContext _context;
        private readonly ISieveProcessor _processor;

        private IOsobaRepository _osobaRepository;
        private IZadatakRepository _zadatakRepository;

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
