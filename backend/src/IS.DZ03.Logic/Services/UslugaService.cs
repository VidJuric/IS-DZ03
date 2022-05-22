using IS.DZ03.Logic.Results;
using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Logic.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services
{
    public class UslugaService : IUslugaService
    {
        protected readonly IAutomobilskeUslugeUnitOfWork UnitOfWork;

        public UslugaService(IAutomobilskeUslugeUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<UslugaResult>> GetAllServices()
        {
            var services = await UnitOfWork.Usluga.GetAll();
            var result = services.Select(s => new UslugaResult(s));
            return result;
        }
    }
}
