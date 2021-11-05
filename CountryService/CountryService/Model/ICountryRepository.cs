using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryService.Model {
    public interface ICountryRepository {
        void AddCountry(Country country);
        Country GetCountry(int id);
        IEnumerable<Country> GetAll();
        void RemoveCountry(Country country);
        void UpdateCountry(Country country);
        IEnumerable<Country> GetAll(string continent);
        IEnumerable<Country> GetAll(string continent, string capital);
    }
}
