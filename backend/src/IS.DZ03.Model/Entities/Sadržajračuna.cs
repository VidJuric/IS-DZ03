#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Sadržajračuna
    {
        public int Id { get; set; }
        public int Količina { get; set; }
        public int Brracuna { get; set; }
        public int? Zadatakid { get; set; }
        public int? Proizvodid { get; set; }

        public virtual Račun BrracunaNavigation { get; set; }
        public virtual Proizvod Proizvod { get; set; }
        public virtual Zadatak Zadatak { get; set; }
    }
}
