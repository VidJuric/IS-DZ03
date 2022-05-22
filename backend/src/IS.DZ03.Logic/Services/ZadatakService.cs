using IS.DZ03.Logic.Results;
using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Logic.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services
{
    public class ZadatakService : IZadatakService
    {
        protected readonly IAutomobilskeUslugeUnitOfWork UnitOfWork;

        public ZadatakService(IAutomobilskeUslugeUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IList<ZadatakResult>> GetEmployeeTasks(long employeeID)
        {
            var employeeTasks = await UnitOfWork.Zadatak.GetEmployeeTasks(employeeID);
            var result = employeeTasks
                .Select(et => new ZadatakResult(et))
                .ToList();

            return result;
        }
    }
}
