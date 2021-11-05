using System;
using System.Runtime.Serialization;

namespace CountryService.Model {
    [Serializable]
    internal class CountryException : Exception {
        

        public CountryException(string message) : base(message) {
        }

       
    }
}