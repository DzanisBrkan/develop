using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USelection.Web.Models
{
    public class IzbornaJedinicaKandidat
    {
        public int Id { get; set; }
        public int? IzbornaJedinicaId { get; set; }
        public string IzbornaJedinica { get; set; }
        public int? KandidatId { get; set; }
        public string Kandidat { get; set; }

        public int? BrojOsvojenihGlasova { get; set; }
        public bool? OverrideFile { get; set; }

    }
}
