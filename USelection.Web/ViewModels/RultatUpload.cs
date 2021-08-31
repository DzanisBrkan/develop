using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USelection.Web.ViewModels
{
    public class RultatUpload
    {
        [Index(0)]
        public string IzbornaJedinica { get; set; } = "";
        [Index(1)]
        public string Kandidat { get; set; } = "";
        [Index(2)]
        public string BrojOsvojenihGlasova { get; set; } = "";
        [Index(3)]
        public string OverrideFile { get; set; } = "";
    }
}
