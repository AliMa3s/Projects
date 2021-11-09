using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTlayer.Model.output
{
    public class StraatRESToutputDTO
    {
        public StraatRESToutputDTO(string id, string straatnaam, string gemeente, int aantalAdressen, List<string> adressen)
        {
            Id = id;
            Straatnaam = straatnaam;
            Gemeente = gemeente;
            AantalAdressen = aantalAdressen;
            Adressen = adressen;
        }
        public string Id { get; set; }
        public string Straatnaam { get; set; }
        public string Gemeente { get; set; }
        public int AantalAdressen { get; set; }
        public List<string> Adressen { get; set; }
    }
}
