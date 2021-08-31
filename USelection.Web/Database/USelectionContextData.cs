using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USelection.Web.Database
{
    public partial class USelection2Context
    {
       
            //Database seeding
            partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
            {
                #region Adding Kandidate 
                modelBuilder.Entity<Kandidat>().HasData(
                    new Kandidat()
                    {
                        Id = 1,
                        ImeIprezime = "Donald Trump",
                        SifraKandidata = "DT"
                    },
                    new Kandidat()
                    {
                        Id = 2,
                        ImeIprezime = "Hillary Clinton",
                        SifraKandidata = "HC"
                    },
                    new Kandidat()
                    {
                        Id = 3,
                        ImeIprezime = "Joe Biden",
                        SifraKandidata = "JB"
                    });
                #endregion


                #region Adding Constituency 
                modelBuilder.Entity<IzbornaJedinica>().HasData(
                    new IzbornaJedinica()
                    {
                        Id = 1,
                        Naziv = "New York",
                    },
                    new IzbornaJedinica()
                    {
                        Id = 2,
                        Naziv = "Washington",
                    },
                    new IzbornaJedinica()
                    {
                        Id = 3,
                        Naziv = "Texas",
                    });
                #endregion



                #region Adding Constituency 
                modelBuilder.Entity<IzbornaJedinicaKandidat>().HasData(
                    new IzbornaJedinicaKandidat()
                    {
                        Id = 1,
                        IzbornaJedinicaId = 1,
                        KandidatId = 1,
                        BrojOsvojenihGlasova = 1233,
                        OverrideFile = false
                    },
                    new IzbornaJedinicaKandidat()
                    {
                        Id = 2,
                        IzbornaJedinicaId = 1,
                        KandidatId = 2,
                        BrojOsvojenihGlasova = 733,
                        OverrideFile = false
                    },
                    new IzbornaJedinicaKandidat()
                    {
                        Id = 3,
                        IzbornaJedinicaId = 1,
                        KandidatId = 3,
                        BrojOsvojenihGlasova = 1003,
                        OverrideFile = false
                    },


                    new IzbornaJedinicaKandidat()
                    {
                        Id = 4,
                        IzbornaJedinicaId = 2,
                        KandidatId = 1,
                        BrojOsvojenihGlasova = 1033,
                        OverrideFile = false
                    },
                    new IzbornaJedinicaKandidat()
                    {
                        Id = 5,
                        IzbornaJedinicaId = 2,
                        KandidatId = 2,
                        BrojOsvojenihGlasova = 1733,
                        OverrideFile = false
                    },
                    new IzbornaJedinicaKandidat()
                    {
                        Id = 6,
                        IzbornaJedinicaId = 2,
                        KandidatId = 3,
                        BrojOsvojenihGlasova = 903,
                        OverrideFile = false
                    },

                     new IzbornaJedinicaKandidat()
                     {
                         Id = 7,
                         IzbornaJedinicaId = 3,
                         KandidatId = 1,
                         BrojOsvojenihGlasova = 533,
                         OverrideFile = false
                     },
                    new IzbornaJedinicaKandidat()
                    {
                        Id = 8,
                        IzbornaJedinicaId = 3,
                        KandidatId = 2,
                        BrojOsvojenihGlasova = 733,
                        OverrideFile = false
                    },
                    new IzbornaJedinicaKandidat()
                    {
                        Id = 9,
                        IzbornaJedinicaId = 3,
                        KandidatId = 3,
                        BrojOsvojenihGlasova = 700,
                        OverrideFile = false
                    });
                #endregion

            }
    }
}
