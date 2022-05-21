#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Sadržajnarudžbe
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int Količina { get; set; }
        public int Narudžbaid { get; set; }
        public int Proizvodid { get; set; }

        public virtual Narudžba Narudžba { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}
