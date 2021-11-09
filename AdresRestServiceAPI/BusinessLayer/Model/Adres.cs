using BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Adres
    {
        public int ID { get; private set; }
        public Straat Straat { get; private set; }
        public string Huisnummer { get; private set; }
        public string Appartementnummer { get; private set; }
        public string Busnummer { get; private set; }
        public int Postcode { get; private set; }
        public Adreslocatie Locatie { get; private set; }

        public Adres(int id, Straat straat, string huisnummer, string appartementnummer, string busnummer
            , int postcode, Adreslocatie locatie)
        {
            ZetID(id);
            ZetStraat(straat);
            ZetHuisnummer(huisnummer);
            this.Appartementnummer = appartementnummer;
            this.Busnummer = busnummer;
            ZetPostcode(postcode);
            ZetLocatie(locatie);
        }
        public Adres(Straat straat, string huisnummer, string appartementnummer, string busnummer
            , int postcode, Adreslocatie locatie)
        {
            ZetStraat(straat);
            ZetHuisnummer(huisnummer);
            this.Appartementnummer = appartementnummer;
            this.Busnummer = busnummer;
            ZetPostcode(postcode);
            ZetLocatie(locatie);
        }
        public void ZetID(int id)
        {
            if (id <= 0)
            {
                AdresException ex = new AdresException("ID niet correct");
                ex.Data.Add("ID", id);
                throw ex;
            }
            ID = id;
        }
        public void ZetStraat(Straat nieuweStraat)
        {
            if (nieuweStraat == null) throw new AdresException("ZetStraat - null");
            if (nieuweStraat == Straat) throw new AdresException("ZetStraat - niet nieuw");
            Straat = nieuweStraat;
        }
        public void ZetHuisnummer(string huisnummer)
        {
            if ((string.IsNullOrWhiteSpace(huisnummer) || (!char.IsDigit(huisnummer[0]))))
            {
                AdresException ex = new AdresException("huisnummer niet correct");
                ex.Data.Add("Huisnummer", huisnummer);
                throw ex;
            }
            Huisnummer = huisnummer;
        }
        public void ZetPostcode(int code)
        {
            if ((code < 1000) || (code > 9999))
            {
                AdresException ex = new AdresException("postcode niet correct");
                ex.Data.Add("Postcode", code);
                throw ex;
            }
            Postcode = code;
        }
        public void ZetLocatie(Adreslocatie locatie)
        {
            if (locatie == null) throw new AdresException("Locatie is null");
            Locatie = locatie;
        }
        public override string ToString()
        {
            return $"Adres : {ID},{Straat.Straatnaam},{Huisnummer},{Appartementnummer},{Busnummer},{Straat.Gemeente.Gemeentenaam}";
        }
    }
}
