using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class StraatService
    {
        private IStraatRepository repo;

        public StraatService(IStraatRepository repo)
        {
            this.repo = repo;
        }

        public List<Straat> GeefstratenGemeente(int gemeenteId)
        {
            try
            {
                return repo.GeefStratenGemeente(gemeenteId);
            }
            catch (Exception ex)
            {
                throw new StraatServiceException("GeefStratenGemeente", ex);
            }
        }
        public Straat GeefStraat(int id)
        {
            try
            {
                return repo.GeefStraat(id);
            }
            catch (Exception ex)
            {
                throw new StraatServiceException("GeefStraat", ex);
            }
        }
    }
}
