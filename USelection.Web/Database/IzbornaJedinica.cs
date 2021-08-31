using System;
using System.Collections.Generic;

#nullable disable

namespace USelection.Web.Database
{
    public partial class IzbornaJedinica
    {
        public IzbornaJedinica()
        {
            IzbornaJedinicaKandidats = new HashSet<IzbornaJedinicaKandidat>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<IzbornaJedinicaKandidat> IzbornaJedinicaKandidats { get; set; }
    }
}
