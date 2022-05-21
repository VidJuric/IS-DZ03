using System.Collections.Generic;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Zaposlenik
    {
        public Zaposlenik()
        {
            Zadatak = new HashSet<Zadatak>();
        }

        public int Zaposlenikid { get; set; }
        public string Oib { get; set; }

        public virtual Osoba OibNavigation { get; set; }
        public virtual ICollection<Zadatak> Zadatak { get; set; }
    }
}
