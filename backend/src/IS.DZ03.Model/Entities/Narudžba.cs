using System.Collections.Generic;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Narudžba
    {
        public Narudžba()
        {
            Sadržajnarudžbe = new HashSet<Sadržajnarudžbe>();
        }

        public int Narudžbaid { get; set; }
        public string Napomena { get; set; }
        public int Korisnickasluzbaid { get; set; }
        public int Dobavljacid { get; set; }

        public virtual Dobavljač Dobavljac { get; set; }
        public virtual KorisničkaSlužba Korisnickasluzba { get; set; }
        public virtual ICollection<Sadržajnarudžbe> Sadržajnarudžbe { get; set; }
    }
}
