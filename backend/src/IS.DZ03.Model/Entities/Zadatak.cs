using System.Collections.Generic;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Zadatak
    {
        public Zadatak()
        {
            Sadržajračuna = new HashSet<Sadržajračuna>();
        }

        public int Zadatakid { get; set; }
        public string Opis { get; set; }
        public int Zaposlenikid { get; set; }
        public int Korisnickasluzbaid { get; set; }
        public int Statuszadatkaid { get; set; }
        public int Uslugaid { get; set; }

        public virtual KorisničkaSlužba Korisnickasluzba { get; set; }
        public virtual Statuszadatka Statuszadatka { get; set; }
        public virtual Usluga Usluga { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }
        public virtual ICollection<Sadržajračuna> Sadržajračuna { get; set; }
    }
}
