using System;

namespace IS.DZ03.Logic.Requests
{
    public class OsobaRequest
    {
        public string Oib { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public char Spol { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
    }
}
