using System;
using System.Collections.Generic;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Osoba
    {
        public Osoba()
        {
            Administracija = new HashSet<Administracija>();
            KorisničkaSlužba = new HashSet<KorisničkaSlužba>();
            Zaposlenik = new HashSet<Zaposlenik>();
        }

        public string Oib { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime Datumrodjenja { get; set; }
        public char Spol { get; set; }
        public DateTime Datumzaposlenja { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }

        public virtual ICollection<Administracija> Administracija { get; set; }
        public virtual ICollection<KorisničkaSlužba> KorisničkaSlužba { get; set; }
        public virtual ICollection<Zaposlenik> Zaposlenik { get; set; }
    }
}
