using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using USelection.Web.Database;
using USelection.Web.ViewModels;

namespace USelection.Web.Controllers
{
    public class ResultsController : Controller
    {
        public USElectionContext _context;
        public ResultsController(USElectionContext context)
        {
            _context = context;
        }


        public IActionResult Prikazi()
        {
            var Rezultati = _context.IzbornaJedinicaKandidats.Include(x => x.Kandidat).Include(x => x.IzbornaJedinica).FirstOrDefault();

            var model = new RezultatIndexVM()
            {
                row = _context.IzbornaJedinicaKandidats
                .Select(x => new RezultatIndexVM.Rows
                {
                    IzbornaJedinica = x.IzbornaJedinica.Naziv,

                    Kandidat = x.Kandidat.ImeIprezime,

                    BrojOsvojenihGlasova = x.BrojOsvojenihGlasova.ToString(),

                    OverrideFile = ((bool)x.OverrideFile).ToString(),

                     Percentage = Math.Round( ((((float)x.BrojOsvojenihGlasova)/20201 ) * 100),0) + "%".ToString()
                })
                  .ToList()
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult Index(List<ViewModels.RultatUpload> tests = null)
        {
            tests = tests == null ? new List<ViewModels.RultatUpload>() : tests;
            List<ViewModels.RultatUpload> podaci = new List<ViewModels.RultatUpload>();

            return View(tests);
        }


        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            try
            {
                #region Upload CSV
                string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }


                #endregion
                var tests = this.GetTestList(file.FileName);
                return Index(tests);
            }
            catch(System.Exception)
            {

                var Error = new Database.Exception();
                Error.Poruka = "(error code: Please insert file )";

                _context.Exceptions.Add(Error);
                _context.SaveChanges();
            }
            
            return Index();
        }
        


        private List<ViewModels.RultatUpload> GetTestList(string fileName)
        {
            List<ViewModels.RultatUpload> tests = new List<ViewModels.RultatUpload>();
            #region Read CSV
            string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var test = csv.GetRecord<ViewModels.RultatUpload>();
                    tests.Add(test);
                }
            }
            #endregion

            #region Create CSV
            path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\FilesTo"}";
            using (var write = new StreamWriter(path + "\\NewFile.csv"))
            {
                using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(tests);
                }
            }
            #endregion

            var Podaci = new Database.IzbornaJedinicaKandidat();
            if (tests.Count() > 0)
            {
                for (int i = 0; i < tests.Count(); i++)
                {
                    var IzbronaJedinicaa = _context.IzbornaJedinicas.Where(x=>x.Naziv == tests[i].IzbornaJedinica).FirstOrDefault();
                    var Kandidati = _context.Kandidats.Where(x => x.ImeIprezime == tests[i].Kandidat).FirstOrDefault();

                    if (tests[i].OverrideFile.Contains("TRUE"))
                    {
                        Podaci = new Database.IzbornaJedinicaKandidat();
                        Podaci.IzbornaJedinicaId = IzbronaJedinicaa.Id;

                        Podaci.KandidatId = Kandidati.Id;

                        Podaci.BrojOsvojenihGlasova = int.Parse(tests[i].BrojOsvojenihGlasova);

                        if (tests[i].OverrideFile.Contains("TRUE"))
                            Podaci.OverrideFile = true;

                        if (tests[i].OverrideFile.Contains("FALSE"))
                            Podaci.OverrideFile = false;

                        _context.IzbornaJedinicaKandidats.Update(Podaci);
                        _context.SaveChanges();
                    }
                    else
                    {
                        Podaci = new Database.IzbornaJedinicaKandidat();
                        Podaci.IzbornaJedinicaId = IzbronaJedinicaa.Id;

                        Podaci.KandidatId = Kandidati.Id;

                        Podaci.BrojOsvojenihGlasova = int.Parse(tests[i].BrojOsvojenihGlasova);

                        if (tests[i].OverrideFile.Contains("TRUE"))
                            Podaci.OverrideFile = true;

                        if (tests[i].OverrideFile.Contains("FALSE"))
                            Podaci.OverrideFile = false;

                        _context.IzbornaJedinicaKandidats.Add(Podaci);
                        _context.SaveChanges();

                    }
                  
                }
            }

            return tests;
        }
    }
}
