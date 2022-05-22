using IS.DZ03.Logic.Results;
using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Logic.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services
{
    public class StatusZadatakaService : IStatusZadatkaService
    {
        protected readonly IAutomobilskeUslugeUnitOfWork UnitOfWork;

        public StatusZadatakaService(IAutomobilskeUslugeUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<StatusZadatkaResult>> GetAllTaskStatuses() { 
            var taskStatuses = await UnitOfWork.StatusZadatka.GetAll();
            var result = taskStatuses.Select(ts => new StatusZadatkaResult(ts));
            return result;
        }
    }
}
