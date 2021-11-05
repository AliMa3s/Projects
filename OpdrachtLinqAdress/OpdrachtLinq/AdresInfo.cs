using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OpdrachtLinq {
   public class AdresInfo {

        private string file;
        private List<Adres> adresData;
        
        public void Start() {
            string Path = @"C:\Users\alima\source\repos\Opdrachten\OpdrachtLinqAdress\adresInfo.txt";
            file = Path;
            DataNaarObject();
        }

        //maken van adresData List dat ik roep in elke methode hieronder
        private void DataNaarObject() {
            adresData = new List<Adres>();
            using (StreamReader sr = new StreamReader(file)) {
                string lijn = "";
                while ((lijn = sr.ReadLine()) != null) {
                    string[] adres = lijn.Split(',');
                    Adres a = new Adres() {
                        Provincie = adres[0],
                        Gemeente = adres[1],
                        Straat = adres[2]
                    };
                    adresData.Add(a);
                }
            }
        }


        //Geef lijst met de provincienamen, alfabetisch gesorteerd.
        public void GetProvincieAlfabetisch() {
            var output = adresData.GroupBy(x => x.Provincie).OrderBy(x => x.Key);
            Console.WriteLine("Provincienamen lijst, Alfabetisch gesorteerd: ");
            foreach (var adres in output) {
                Console.WriteLine(" -" + adres.Key);
            }
            Console.WriteLine("-------------------");
        }

        

        //Geef lijst van straatnamen voor opgegeven gemeente.
        public void GetStraatVanStad(string stad) {
            //convert string naar juist formaat
            stad = ConvertNaarValidFormaat(stad);
            var output = adresData.Where(x => x.Gemeente == stad);
            Console.WriteLine($"Straatnamen Lijst voor stad {stad} :");
            foreach (var adres in output) {
                Console.WriteLine(" -" + adres.Straat);
            }
            Console.WriteLine("-------------------");
        }

        //Selecteer de straatnaam die het meest keren voorkomt en druk voor elk voorkomen de provincienaam,
        //gemeentenaam en straatnaam af.  Sortering op basis van provincie en gemeente.
        public void GetMeestVoorkomtStraat() {
            var straat = adresData.GroupBy(x => x.Straat).Select((x, straat) => new { aantal = x.Count(), straat = x.Key })
                .OrderByDescending(x => x.aantal).First().straat;
            var output = adresData.Where(x => x.Straat == straat).OrderBy(x => x.Provincie).ThenBy(x => x.Gemeente);
            Console.WriteLine($"Meest Voorkomende straatnamen : {straat}");
            Console.WriteLine("Komt voor in volgende gemeete :");
            foreach (var adres in output) {
                Console.WriteLine($"    -{adres.Provincie} * {adres.Gemeente} * {adres.Straat}");
            }
            Console.WriteLine("-------------------");

        }
        //Voorzie een analoge functie die de meest voorkomende straatnamen weergeeft met een parameter
        //die aangeefthoeveel straatnamen.  Output analoog aanvoorgaande functie.
        public void GetAantalMeestVoorkomtStraat(int aantal) {
            var vraag = adresData.GroupBy(x => x.Straat).Select((x, straat) => new { aantal = x.Count(), straat = x.Key }).Where(x => x.aantal == aantal);
            if (vraag.Count() == 0) {
                Console.WriteLine($"Geen straatnamen gevonden met {aantal} keer voorkomt.");
            } else {
                Console.WriteLine($"{(vraag.Count() <=1 ? "Straat" : "Straten")} die {aantal} keer {(vraag.Count() <=1 ? "voorkomt" : "voorkomen")}:");
                foreach (var straat in vraag) {
                    Console.WriteLine($"    - {straat.straat}");
                }
            }

            //print de vraag
            if (vraag.Count() != 0) {
                Console.WriteLine("\n Detailleerd overzicht: ");
                foreach (var item in vraag) {
                    var vragen = adresData.Where(x => x.Straat == item.straat).OrderBy(x => x.Provincie).ThenBy(x => x.Gemeente);
                    foreach (var adres in vragen) {
                        Console.WriteLine($"    - {adres.Provincie} * {adres.Gemeente} * {adres.Straat}");
                    }
                }
            }
            Console.WriteLine("-------------------");
        }

        //Voorzie een functie die voor 2 opgegeven gemeenten de gemeenschappelijke lijst van straatnamen weergeeft.
        public void GetStraatenGemeenshcappelijkVan2Gemeentes(string stad1, string stad2) {
            //Convert string naar juiste formaat
            stad1 = ConvertNaarValidFormaat(stad1);
            stad2 = ConvertNaarValidFormaat(stad2);

            var straat1 = adresData.Where(x => x.Gemeente == stad1);
            var straat2 = adresData.Where(x => x.Gemeente == stad2);
            var GemeenschappelijkStraaten = straat1.Select(x => x.Straat).Intersect(straat2.Select(x => x.Straat));
            Console.WriteLine($"Geemschappelijk straten voor {stad1} en {stad2} : ");
            foreach (var s in GemeenschappelijkStraaten) {
                Console.WriteLine(" -" +s);
            }
            Console.WriteLine("-------------------");
        }

        //Voorzie een functie die de straatnamen weergeeft die enkel voorkomen in de opgegeven gemeente,
        //maar die niet voorkomen in een lijst vananderegemeenten.
        public void GetUniekeStraatenVanStad(string stad) {
            //Convert string naar juiste formaat
            stad = ConvertNaarValidFormaat(stad);
            var straat = adresData.Where(x => x.Gemeente == stad).Select(x => x.Straat);
            var uniek = straat.Except(adresData.Where(x => x.Gemeente != stad).Select(x => x.Straat));
            Console.WriteLine($"Unieke straten in {stad} : ");
            foreach (var s in uniek) {
                Console.WriteLine(" - " +s);
            }
            Console.WriteLine("-------------------");
        }

        //Maak een functie die de gemeente weergeeft met het hoogste aantal straatnamen.
        public void GetHoogstAantalStraaten() {
            var vraag = adresData.GroupBy(x=>x.Gemeente).Select((x, adres)=> new { aantal = x.Count(), gemeente = x.Key })
            .OrderByDescending(x => x.aantal).First().gemeente;
            Console.WriteLine($"Gemeente met hoogst aantal straatnamen : {vraag}");
            Console.WriteLine("-------------------");
        }

        //Geef de langste straatnaam weer.
        public void GetLangsteStraat() {
            var vraag = adresData.OrderByDescending(x => x.Straat.Length).First();
            Console.WriteLine($"Langste straatnaam: {vraag.Straat}");
            Console.WriteLine("-------------------");
        }
        //Geeft de naast de langste straatnaam ook de gemeente en provincie weer.
        public void GetLangsteStraatMetGemEnProv() {
            var vraag = adresData.OrderByDescending(x => x.Straat.Length).First();
            Console.WriteLine($"Langste straatnaam: {vraag.Straat}");
            Console.WriteLine($"Gelegen in {vraag.Gemeente} ({vraag.Provincie})");
            Console.WriteLine("-------------------");
        }
        //Geef een lijst met straatnamen die uniek zijn (en toon ook gemeente en provincie)
        public void GetUniekeStraaten() {
            var uniekestraaten = adresData.GroupBy(x => x.Straat).Select((x, straat) => new { aantal = x.Count(), straat = x.Key })
                .Where(x => x.aantal == 1);
            Console.WriteLine(uniekestraaten.Count());
            Console.WriteLine("Lijst met unieke straatnamen");
            foreach (var straat in uniekestraaten) {
                var adres = adresData.Where(x => x.Straat == straat.straat).First();
                Console.WriteLine($"    - {adres.Provincie} * {adres.Gemeente} * {adres.Straat}");
            }
            Console.WriteLine("-------------------");
        }

        //Geef een lijst met straatnamen die uniek zijn voor een opgegeven gemeente.
        public void GetUniekeStraatenVanGemeente(string stad) {
            var uniekestraaten = adresData.Where(s => s.Gemeente == stad).Select(s => s.Straat).Distinct().ToList();
            Console.WriteLine($"Lijst met unieke straaten in {stad}");
            foreach (var v in uniekestraaten) {
                Console.WriteLine($"    - " + v);
            }
            Console.WriteLine("-------------------");
        }


        //method om to converteren naar juiste formaat
        static string ConvertNaarValidFormaat(string s) {
            //eerste elemente naar string en to upper + s substring van index1 to lower
            return s.First().ToString().ToUpper() + s.Substring(1).ToLower();
        }

    }
}
