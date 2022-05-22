using IS.DZ03.Logic.Requests;
using IS.DZ03.Logic.Results;
using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Logic.UnitOfWork;
using IS.DZ03.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<ZadatakInfoResult>> GetEmployeeTasks(long employeeID)
        {
            var employeeTasks = await UnitOfWork.Zadatak.GetEmployeeTasks(employeeID);
            var result = employeeTasks
                .Select(et => new ZadatakInfoResult(et, $"{et.Korisnickasluzba.OibNavigation.Ime} {et.Korisnickasluzba.OibNavigation.Prezime}"))
                .ToList();

            return result;
        }

        public async Task<ZadatakResult> CreateTask(ZadatakRequest task)
        {
            var entity = new Zadatak
            {
                Opis = task.Opis,
                Zaposlenikid = task.ZaposlenikID,
                Korisnickasluzbaid = task.KorisnickasluzbaID,
                Statuszadatkaid = task.StatusZadatkaID,
                Uslugaid = task.UslugaID
            };

            UnitOfWork.Zadatak.Add(entity);
            _ = UnitOfWork.Save();

            return new ZadatakResult(entity);
        }
        public async Task<ZadatakResult> UpdateTask(int taskID, ZadatakRequest task)
        {
            var entity = await UnitOfWork.Zadatak.GetById(taskID);

            entity.Opis = task.Opis;
            entity.Statuszadatkaid = task.StatusZadatkaID;
            entity.Uslugaid = task.UslugaID;

            _ = UnitOfWork.Save();

            return new ZadatakResult(entity);
        }

        public async Task DeleteTask(int taskID)
        {
            var entity = await UnitOfWork.Zadatak.GetById(taskID);

            UnitOfWork.Zadatak.Remove(entity);
            _ = UnitOfWork.Save();
        }
    }
}
