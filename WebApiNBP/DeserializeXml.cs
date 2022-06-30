using System.Diagnostics;
using System.Net;
using System.Xml.Serialization;


namespace WebApiNBP
{
    internal static class DeserializeXml
    {
       public static void Main(DataContext ctx)
        {
            var filepath = @"https://www.nbp.pl/kursy/xml/a071z220412.xml";
            WebClient client = new WebClient();
            var xml =client.DownloadString(filepath);
            var serializer = new XmlSerializer(typeof(Tabela_kursow));
            using (var reader = new StringReader(xml))
            {
                var NBP = (Tabela_kursow)serializer.Deserialize(reader);
                NBP.Pozycja.ForEach((poz) => 
               {
                   poz.Kurs_sredni = poz.Nazwa_waluty;
                   var pozycja_z_bazy = ctx.Pozycje.FirstOrDefault(x => x.Nazwa_waluty == poz.Nazwa_waluty);

                   if( pozycja_z_bazy == null)
                   {
                       pozycja_z_bazy = new Pozycja();
                       pozycja_z_bazy.Nazwa_waluty = poz.Nazwa_waluty;
                       pozycja_z_bazy.Przelicznik = poz.Przelicznik;
                       pozycja_z_bazy.Kod_waluty = poz.Kod_waluty;
                       pozycja_z_bazy.Kurs_sredni = poz.Kurs_sredni;

                       //przypisz wartosci 
                       ctx.Add(pozycja_z_bazy);

                   }
                   else
                   {
                       pozycja_z_bazy = new Pozycja();
                       pozycja_z_bazy.Nazwa_waluty =  poz.Nazwa_waluty;
                       pozycja_z_bazy.Przelicznik = poz.Przelicznik;
                       pozycja_z_bazy.Kod_waluty = poz.Kod_waluty;
                       pozycja_z_bazy.Kurs_sredni = poz.Kurs_sredni;
                       //przypisz wartosci 
                       ctx.Update(pozycja_z_bazy);
                   }

                   
                   // pobierz kues po nazwie zwie 
                   // podmien wartosci 
                   // update na bazie 
               }
               
                );
                ctx.SaveChanges();
                  Debugger.Break();
            }
        }
    }
}
