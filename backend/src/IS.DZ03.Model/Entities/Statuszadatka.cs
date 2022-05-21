using System.Collections.Generic;

#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Statuszadatka
    {
        public Statuszadatka()
        {
            Zadatak = new HashSet<Zadatak>();
        }

        public int Statuszadatkaid { get; set; }
        public string Opisstatusa { get; set; }

        public virtual ICollection<Zadatak> Zadatak { get; set; }
    }
}
