using System.Collections.Generic;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class KorisničkaSlužba
    {
        public KorisničkaSlužba()
        {
            Narudžba = new HashSet<Narudžba>();
            Račun = new HashSet<Račun>();
            Zadatak = new HashSet<Zadatak>();
        }

        public int Korisnickasluzbaid { get; set; }
        public string Oib { get; set; }

        public virtual Osoba OibNavigation { get; set; }
        public virtual ICollection<Narudžba> Narudžba { get; set; }
        public virtual ICollection<Račun> Račun { get; set; }
        public virtual ICollection<Zadatak> Zadatak { get; set; }
    }
}
