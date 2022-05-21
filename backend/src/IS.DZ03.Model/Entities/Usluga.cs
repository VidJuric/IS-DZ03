using System.Collections.Generic;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Usluga
    {
        public Usluga()
        {
            Zadatak = new HashSet<Zadatak>();
        }

        public int Uslugaid { get; set; }
        public string Opisusluga { get; set; }
        public decimal Cijena { get; set; }

        public virtual ICollection<Zadatak> Zadatak { get; set; }
    }
}
