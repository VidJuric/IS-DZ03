using IS.DZ03.Model.Entities;
using System;

namespace IS.DZ03.Logic.Results
{
    public class ZadatakResult
    {
        public ZadatakResult(Zadatak zadatak)
        {
            if (zadatak is null)
            {
                throw new ArgumentException("Argument can't be null");
            }

            ZadatakID = zadatak.Zadatakid;
            Opis = zadatak.Opis;
            ZaposlenikID = zadatak.Zaposlenikid;
            KorisnickasluzbaID = zadatak.Korisnickasluzbaid;
            StatusZadatkaID = zadatak.Statuszadatkaid;
            UslugaID = zadatak.Uslugaid;
        }

        public int ZadatakID { get; set; }
        public string Opis { get; set; }
        public int ZaposlenikID { get; set; }
        public int KorisnickasluzbaID { get; set; }
        public int StatusZadatkaID { get; set; }
        public int UslugaID { get; set; }
    }
}
