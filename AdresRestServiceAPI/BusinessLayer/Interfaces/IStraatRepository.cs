using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IStraatRepository
    {
        List<Straat> GeefStratenGemeente(int gemeenteId);
        Straat GeefStraat(int id);
    }
}
