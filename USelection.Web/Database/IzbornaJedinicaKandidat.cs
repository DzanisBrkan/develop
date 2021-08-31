using System;
using System.Collections.Generic;

#nullable disable

namespace USelection.Web.Database
{
    public partial class IzbornaJedinicaKandidat
    {
        public int Id { get; set; }
        public int? IzbornaJedinicaId { get; set; }
        public int? KandidatId { get; set; }
        public int? BrojOsvojenihGlasova { get; set; }
        public bool? OverrideFile { get; set; }

        public virtual IzbornaJedinica IzbornaJedinica { get; set; }
        public virtual Kandidat Kandidat { get; set; }
    }
}
