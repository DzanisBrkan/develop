using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USelection.Web.ViewModels
{
    public class RezultatIndexVM
    {

        //public int ID { get; set; }
        public List<Rows> row { get; set; }

        public class Rows
        {
            public int IzbornaJedinicaID { get; set; }
            public string IzbornaJedinica { get; set; }
            public int KandidatID { get; set; }

            public string Kandidat { get; set; }
            public string BrojOsvojenihGlasova { get; set; }
            public string Percentage { get; set; }

            public string OverrideFile { get; set; }



        }
    }
}
