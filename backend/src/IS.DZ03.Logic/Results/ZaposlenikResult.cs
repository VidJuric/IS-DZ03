using IS.DZ03.Model.Entities;
using System;

namespace IS.DZ03.Logic.Results
{
    public class ZaposlenikResult
    {
        public ZaposlenikResult(Zaposlenik zaposlenik)
        {
            if (zaposlenik is null)
            {
                throw new ArgumentException("Argument can't be null");
            }

            ZaposlenikID = zaposlenik.Zaposlenikid;
            OIB = zaposlenik.Oib;
        }

        public int ZaposlenikID { get; set; }
        public string OIB { get; set; }
    }
}
