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
    public class AdresService
    {
        private IAdresRepository repo;

        public AdresService(IAdresRepository repo)
        {
            this.repo = repo;
        }
        public IEnumerable<Adres> GeefAdressenStraat(int id)
        {
            try
            {
                return repo.GeefAdressenStraat(id);
            }
            catch (Exception ex)
            {
                throw new AdresServiceException("GeefAdressenStraat", ex);
            }
        }
    }
}
