using IS.DZ03.Model.Entities;
using System;

namespace IS.DZ03.Logic.Results
{
    public class EmployeeInfoResult
    {
        public EmployeeInfoResult(Osoba osoba, int employeeID)
        {
            if (osoba is null)
            {
                throw new ArgumentException("Argument can't be null");
            }

            Oib = osoba.Oib;
            Ime = osoba.Ime;
            Prezime = osoba.Prezime;
            DatumRodjenja = osoba.Datumrodjenja;
            Spol = osoba.Spol;
            DatumZaposlenja = osoba.Datumzaposlenja;
            Email = osoba.Email;
            ZaposlenikID = employeeID;
        }

        public string Oib { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public char Spol { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string Email { get; set; }
        public int ZaposlenikID { get; set; }
    }
}
