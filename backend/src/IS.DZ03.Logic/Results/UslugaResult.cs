using IS.DZ03.Model.Entities;
using System;

namespace IS.DZ03.Logic.Results
{
    public class UslugaResult
    {
        public UslugaResult(Usluga usluga)
        {
            if (usluga is null)
            {
                throw new ArgumentException("Argument can't be null");
            }

            UslugaID = usluga.Uslugaid;
            OpisUsluga = usluga.Opisusluga;
            Cijena = usluga.Cijena;
        }

        public int UslugaID { get; set; }
        public string OpisUsluga { get; set; }
        public decimal Cijena { get; set; }
    }
}
