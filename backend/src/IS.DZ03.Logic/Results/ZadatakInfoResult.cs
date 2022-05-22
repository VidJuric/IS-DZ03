using IS.DZ03.Model.Entities;
using System;

namespace IS.DZ03.Logic.Results
{
    public class ZadatakInfoResult
    {
        public ZadatakInfoResult(Zadatak zadatak, string imePrezime)
        {
            if (zadatak is null)
            {
                throw new ArgumentException("Argument can't be null");
            }

            ZadatakID = zadatak.Zadatakid;
            Opis = zadatak.Opis;
            ZaposlenikID = zadatak.Zaposlenikid;
            KorisnickasluzbaID = zadatak.Korisnickasluzbaid;
            KorisnickaSluzbaImePrezime = imePrezime;
            StatusZadatkaID = zadatak.Statuszadatkaid;
            UslugaID = zadatak.Uslugaid;
        }

        public int ZadatakID { get; set; }
        public string Opis { get; set; }
        public int ZaposlenikID { get; set; }
        public int KorisnickasluzbaID { get; set; }
        public string KorisnickaSluzbaImePrezime { get; set; }
        public int StatusZadatkaID { get; set; }
        public int UslugaID { get; set; }
    }
}
