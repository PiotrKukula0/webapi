using System;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiNBP;
using WebApiNBP.Data;

namespace FunctionAppTimeTrigger
{
    public class Function1
    {
        private DataContext _dataContext;

        public Function1(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [FunctionName("Function1")]
        public static void Main(DataContext ctx)
        {
            var filepath = @"https://www.nbp.pl/kursy/xml/a071z220412.xml";
            WebClient client = new WebClient();
            var xml = client.DownloadString(filepath);
            var serializer = new XmlSerializer(typeof(Tabela_kursow));
            using (var reader = new StringReader(xml))
            {
                var NBP = (Tabela_kursow)serializer.Deserialize(reader);
                NBP.Pozycja.ForEach((poz) =>
                {
                    poz.Kurs_sredni = poz.Nazwa_waluty;
                    var pozycja_z_bazy = ctx.Pozycje.FirstOrDefault(x => x.Nazwa_waluty == poz.Nazwa_waluty);

                    if (pozycja_z_bazy == null)
                    {
                        pozycja_z_bazy = new Pozycja();
                        pozycja_z_bazy.Nazwa_waluty = poz.Nazwa_waluty;
                        pozycja_z_bazy.Przelicznik = poz.Przelicznik;
                        pozycja_z_bazy.Kod_waluty = poz.Kod_waluty;
                        pozycja_z_bazy.Kurs_sredni = poz.Kurs_sredni;

                        ctx.Add(pozycja_z_bazy);

                    }
                    else
                    {
                        pozycja_z_bazy = new Pozycja();
                        pozycja_z_bazy.Nazwa_waluty = poz.Nazwa_waluty;
                        pozycja_z_bazy.Przelicznik = poz.Przelicznik;
                        pozycja_z_bazy.Kod_waluty = poz.Kod_waluty;
                        pozycja_z_bazy.Kurs_sredni = poz.Kurs_sredni;

                        ctx.Update(pozycja_z_bazy);
                    }
                }
                );
                ctx.SaveChanges();
                Debugger.Break();
            }
        }
        public void Run([TimerTrigger("* * * * *")]TimerInfo myTimer, ILogger log)
        {

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var list = _dataContext.Pozycje.ToList();
            log.LogInformation(" "+list.Count);
            
        }
    }
}
