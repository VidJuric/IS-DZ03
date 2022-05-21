using IS.DZ03.Logic.Results;
using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Logic.UnitOfWork;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services
{
    public class OsobaService : IOsobaService
    {
        protected readonly IAutomobilskeUslugeUnitOfWork UnitOfWork;

        public OsobaService(IAutomobilskeUslugeUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<OsobaResult>> GetAllEmployees(SieveModel model)
        {
            var employees = await UnitOfWork.Osoba.GetEmployees(model);
            var result = employees.Select(e => new OsobaResult(e));
            return result;
        }

    }
}
