using BusinessLayer.Model;
using BusinessLayer.Services;
using RESTlayer.Exceptions;
using RESTlayer.Model.output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTlayer.Mappers
{
    public static class MapFromDomain
    {
        public static GemeenteRESToutputDTO MapFromGemeenteDomain(string url,Gemeente gemeente,StraatService straatService)
        {
            try
            {
                string gemeenteURL = $"{url}/gemeente/{gemeente.NIScode}";
                List<string> straten = straatService.GeefstratenGemeente(gemeente.NIScode)
                    .Select(x => gemeenteURL + $"/straat/{x.ID}").ToList();
                GemeenteRESToutputDTO dto=new GemeenteRESToutputDTO(gemeenteURL,gemeente.NIScode,
                    gemeente.Gemeentenaam,straten.Count,straten);
                return dto;
            }
            catch (Exception ex)
            {
                throw new MapException("MapFromGemeenteDomain", ex);
            }
        }
        public static object MapFromStraatDomain(string url, Straat straat, AdresService adresService)
        {
            try
            {
                string gemeenteURL = $"{url}/gemeente/{straat.Gemeente.NIScode}";
                string straatURL = gemeenteURL + $"/straat/{straat.ID}";
                List<string> adressen = adresService.GeefAdressenStraat(straat.ID).Select(x => straatURL + $"/adres/{x.ID}").ToList(); ;
                StraatRESToutputDTO dto = new StraatRESToutputDTO(straatURL, straat.Straatnaam, gemeenteURL, adressen.Count, adressen);
                return dto;
            }
            catch (Exception ex)
            {
                throw new MapException("MapFromStraatDomain", ex);
            }
        }
    }
}
