using IS.DZ03.Logic.Results;
using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Logic.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services
{
    public class ZaposlenikService : IZaposlenikService
    {
        protected readonly IAutomobilskeUslugeUnitOfWork UnitOfWork;

        public ZaposlenikService(IAutomobilskeUslugeUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<ZaposlenikResult>> GetAllEmployees()
        {
            var employees = await UnitOfWork.Zaposlenik.GetAll();
            var result = employees.Select(s => new ZaposlenikResult(s));
            return result;
        }
    }
}
