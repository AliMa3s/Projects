using BusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Straat
    {
        public int ID { get; private set; }
        public string Straatnaam { get; private set; }
        public Gemeente Gemeente { get; private set; }

        public Straat(int ID, string straatnaam, Gemeente gemeente) : this(straatnaam, gemeente)
        {
            ZetID(ID);
        }
        public Straat(string straatnaam, Gemeente gemeente) : this(straatnaam)
        {
            ZetGemeente(gemeente);
        }
        public Straat(string straatnaam)
        {
            ZetStraatnaam(straatnaam);
        }

        public void ZetStraatnaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                StraatException ex = new StraatException("naam niet correct");
                ex.Data.Add("Straatnaam", naam);
                throw ex;
            }
            Straatnaam = naam;
        }
        public void ZetID(int id)
        {
            if (id <= 0)
            {
                StraatException ex = new StraatException("ID niet correct");
                ex.Data.Add("ID", id);
                throw ex;
            }
            ID = id;
        }
        public void ZetGemeente(Gemeente nieuweGemeente)
        {
            if (nieuweGemeente == null) throw new StraatException("ZetGemeente - null");
            if (nieuweGemeente == Gemeente) throw new StraatException("ZetGemeente - niet nieuw");
            Gemeente = nieuweGemeente;
        }

        override public string ToString()
        {
            return ID.ToString() + "," + Straatnaam + "," + Gemeente.ToString();
        }
    }
}
