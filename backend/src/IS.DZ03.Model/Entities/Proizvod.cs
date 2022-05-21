using System.Collections.Generic;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Proizvod
    {
        public Proizvod()
        {
            Sadržajnarudžbe = new HashSet<Sadržajnarudžbe>();
            Sadržajračuna = new HashSet<Sadržajračuna>();
        }

        public int Proizvodid { get; set; }
        public string Nazivproizvoda { get; set; }
        public int Količinaproizvoda { get; set; }
        public decimal Cijena { get; set; }

        public virtual ICollection<Sadržajnarudžbe> Sadržajnarudžbe { get; set; }
        public virtual ICollection<Sadržajračuna> Sadržajračuna { get; set; }
    }
}
