#nullable disable

namespace IS.DZ03.Model.Entities
{
    public partial class Administracija
    {
        public int Administracijaid { get; set; }
        public string Oib { get; set; }

        public virtual Osoba OibNavigation { get; set; }
    }
}
