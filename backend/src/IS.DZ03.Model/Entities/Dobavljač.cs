using System.Collections.Generic;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Dobavljač
    {
        public Dobavljač()
        {
            Narudžba = new HashSet<Narudžba>();
        }

        public int Dobavljacid { get; set; }
        public string Nazivdobavljača { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Narudžba> Narudžba { get; set; }
    }
}
