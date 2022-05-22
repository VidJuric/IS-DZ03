using IS.DZ03.Logic.Requests;
using IS.DZ03.Logic.Results;
using IS.DZ03.Logic.Services.Interfaces;
using IS.DZ03.Logic.UnitOfWork;
using IS.DZ03.Model.Entities;
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

        public async Task<IEnumerable<CustomerSupportInfoResult>> GetAllCustomerSupport()
        {
            var persons = await UnitOfWork.Osoba.GetCustomerSupport();
            persons = persons.Where(p => p.KorisničkaSlužba.Count > 0);

            var result = persons.Select(p => new CustomerSupportInfoResult(p, p.KorisničkaSlužba.First().Korisnickasluzbaid)).OrderBy(p => p.KorisnickaSluzbaID);

            return result;
        }

        public async Task<OsobaResult> AddEmployee(OsobaRequest employee)
        {
            var entityOsoba = new Osoba
            {
                Oib = employee.Oib,
                Ime = employee.Ime,
                Prezime = employee.Prezime,
                Datumrodjenja = employee.DatumRodjenja,
                Spol = employee.Spol,
                Datumzaposlenja = employee.DatumZaposlenja,
                Email = employee.Email,
                Lozinka = employee.Lozinka,
            };

            var entityZaposlenik = new Zaposlenik
            {
                Oib = employee.Oib
            };

            UnitOfWork.Osoba.Add(entityOsoba);
            UnitOfWork.Zaposlenik.Add(entityZaposlenik);

            _ = UnitOfWork.Save();

            return new OsobaResult(entityOsoba);
        }

        public async Task<OsobaResult> EditEmployee(string oib, OsobaRequest employee)
        {
            var entity = await UnitOfWork.Osoba.GetPersonByOIB(oib);

            entity.Ime = employee.Ime;
            entity.Prezime = employee.Prezime;
            entity.Datumrodjenja = employee.DatumRodjenja;
            entity.Spol = employee.Spol;
            entity.Datumzaposlenja = employee.DatumZaposlenja;
            entity.Email = employee.Email;
            entity.Lozinka = employee.Lozinka;

            _ = UnitOfWork.Save();

            return new OsobaResult(entity);
        }

        public async Task DeleteEmployee(string oib)
        {
            var entityOsoba = await UnitOfWork.Osoba.GetPersonByOIB(oib);
            var entityZaposlenik = await UnitOfWork.Zaposlenik.GetEmployeeByOIB(oib);

            UnitOfWork.Zaposlenik.Remove(entityZaposlenik);
            UnitOfWork.Osoba.Remove(entityOsoba);

            _ = UnitOfWork.Save();
        }
    }
}
