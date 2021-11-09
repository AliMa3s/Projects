using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IGemeenteRepository
    {
        Gemeente GeefGemeente(int id);
        bool HeeftGemeente(int nIScode);
        void VoegGemeenteToe(Gemeente gemeente);
        bool HeeftStraten(int id);
        void VerwijderGemeente(int id);
        void UpdateGemeente(Gemeente gemeente);
    }
}
