using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Logic.UnitOfWork;
using IS.DZ03.Model.Entities;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Osoba>> GetAllEmployees()
        {
            return await UnitOfWork.Osoba.GetAll();
        }
    }
}
