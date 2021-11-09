using BusinessLayer.Model;
using RESTlayer.Exceptions;
using RESTlayer.Model.input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTlayer.Mappers
{
    public static class MapToDomain
    {
        public static Gemeente MapToGemeenteDomain(GemeenteRESTinputDTO dto)
        {
            try
            {
                Gemeente gemeente = new Gemeente(dto.NIScode, dto.Naam);
                return gemeente;
            }
            catch (Exception ex)
            {
                throw new MapException("MapToGemeenteException", ex);
            }
        }
    }
}
