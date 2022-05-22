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

        public async Task<IEnumerable<EmployeeInfoResult>> GetAllEmployees(SieveModel model)
        {
            var persons = await UnitOfWork.Osoba.GetEmployees(model);
            persons = persons.Where(p => p.Zaposlenik.Count > 0);

            var result = persons.Select(p => new EmployeeInfoResult(p, p.Zaposlenik.First().Zaposlenikid)).OrderBy(p => p.ZaposlenikID);

            return result;
        }

    }
}
