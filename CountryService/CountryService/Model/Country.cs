using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryService.Model {

    public class Country {
        public Country() {
        }

        public Country(string name, string capital, string continent) {
            Name = name;
            Capital = capital;
            Continent = continent;
        }

        public Country(int id, string name, string capital, string continent) {
            Id = id;
            Name = name;
            Capital = capital;
            Continent = continent;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Continent { get; set; }


    }
}
