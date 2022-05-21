using System.Collections.Generic;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Račun
    {
        public Račun()
        {
            Sadržajračuna = new HashSet<Sadržajračuna>();
        }

        public int Brracuna { get; set; }
        public int Korisnickasluzbaid { get; set; }

        public virtual KorisničkaSlužba Korisnickasluzba { get; set; }
        public virtual ICollection<Sadržajračuna> Sadržajračuna { get; set; }
    }
}
