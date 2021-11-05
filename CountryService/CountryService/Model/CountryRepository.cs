using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryService.Model {
    public class CountryRepository : ICountryRepository {

        private Dictionary<int, Country> data = new Dictionary<int, Country>();

        public CountryRepository() {

            data.Add(1, new Country(1, "Belgie", "Brussel", "Europa"));
            data.Add(2, new Country(2, "Peru", "Lima", "Zuid-Amerika"));
            data.Add(3, new Country(3, "Duitsland", "Berlijn", "Europa"));
            data.Add(4, new Country(4, "Zweden", "Stockholm", "Europa"));
            data.Add(5, new Country(5, "Noorwegen", "Oslo", "Europa"));
        }

        //All the interface Methods to be implemented in repository
        public IEnumerable<Country> GetAll() {
            return data.Values;
        }

        public Country GetCountry(int id) {
            if (data.ContainsKey(id)) {
                return data[id];
            } else {
                throw new CountryException("Country doesn't exist");
            }
        }

        public void AddCountry(Country country) {
            if (!data.ContainsKey(country.Id)) {
                data.Add(country.Id, country);
            } else {
                throw new CountryException("Country already exist");
                
            }
        }

        public void RemoveCountry(Country country) {
            if (data.ContainsKey(country.Id))
                data.Remove(country.Id);
            else
                throw new CountryException("Country doesn't exist");
        }

        public void UpdateCountry(Country country) {
            if (data.ContainsKey(country.Id))
                data[country.Id] = country;
            else
                throw new CountryException("Country doesn't exist");
        }

        public IEnumerable<Country> GetAll(string continent) {
            return data.Values.Where(x => x.Continent == continent);
        }

        public IEnumerable<Country> GetAll(string continent, string capital) {
            return data.Values.Where(x => x.Continent == continent && x.Capital == capital);
        }
    }
}
