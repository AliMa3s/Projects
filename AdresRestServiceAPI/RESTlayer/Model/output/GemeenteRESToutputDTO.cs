using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTlayer.Model.output
{
    public class GemeenteRESToutputDTO
    {
        public GemeenteRESToutputDTO(string id, int nIScode, string naam, int aantalStraten, List<string> straten)
        {
            Id = id;
            NIScode = nIScode;
            Naam = naam;
            AantalStraten = aantalStraten;
            Straten = straten;
        }
        public string Id { get; set; }
        public int NIScode { get; set; }
        public string Naam { get; set; }
        public int AantalStraten { get; set; }
        public List<string> Straten { get; set; }
    }
}
