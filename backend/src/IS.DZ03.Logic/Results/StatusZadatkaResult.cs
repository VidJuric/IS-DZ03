using IS.DZ03.Model.Entities;
using System;

namespace IS.DZ03.Logic.Results
{
    public class StatusZadatkaResult
    {
        public StatusZadatkaResult(Statuszadatka statusZadatka)
        {
            if (statusZadatka is null)
            {
                throw new ArgumentException("Argument can't be null");
            }

            StatusZadatkaID = statusZadatka.Statuszadatkaid;
            OpisStatusa = statusZadatka.Opisstatusa;
        }

        public int StatusZadatkaID { get; set; }
        public string OpisStatusa { get; set; }
    }
}
