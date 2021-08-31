using System;
using System.Collections.Generic;

#nullable disable

namespace USelection.Web.Database
{
    public partial class Kandidat
    {
        public Kandidat()
        {
            IzbornaJedinicaKandidats = new HashSet<IzbornaJedinicaKandidat>();
        }

        public int Id { get; set; }
        public string ImeIprezime { get; set; }
        public string SifraKandidata { get; set; }

        public virtual ICollection<IzbornaJedinicaKandidat> IzbornaJedinicaKandidats { get; set; }
    }
}
