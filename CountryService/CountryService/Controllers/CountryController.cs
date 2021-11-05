using CountryService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase {
        private ICountryRepository repo;

        public CountryController(ICountryRepository repo) {
            this.repo = repo;
        }

        /*Get: api/Country*/
        /* http://localhost:49164/api/country/ */
        //[HttpGet]
        //public IEnumerable<Country> Get() {
        //    return repo.GetAll();
        //}

        ////Get: api/Country/5
        /*For this test use http://localhost:----/api/Country/1-5 and > 5 is equals to error that we are handeling */
        /* http://localhost:49164/api/country/3 */

        //[HttpGet("{id}", Name = "Get")]
        //public Country Get(int id) {
        //    return repo.GetCountry(id);
        //}

        /*We try the up code where the id doesnt exist but in try catch */
        /* http://localhost:49164/api/country/9 */

        //[HttpGet("{id}", Name = "Get")]
        //public Country Get(int id) {
        //    try {
        //        return repo.GetCountry(id);

        //    } catch (CountryException ex) {

        //        return null;
        //    }
        //}


        /*We try the up code but this time instead of 204 No Content we send 400 Bad Request */
        /* http://localhost:49164/api/country/9 */
        //[HttpGet("{id}", Name = "Get")]
        //public Country Get(int id) {
        //    try {
        //        return repo.GetCountry(id);

        //    } catch (CountryException ex) {
        //        Response.StatusCode = 400;
        //        return null;
        //    }
        //}

        /*IActionResulten ActionResult<T>
         * In plaats van een specifiek type terug te geven kunnen we ook een 
         * IActionResult teruggeven die een statuscode combineert methet resultaat (data).Deze interface wordt 
         * door een aantal klassen geïmplementeerd zoals Ok(), NotFound(), NoContent() en BadRequest().
         * De methode kan dan herschreven worden zoals in het volgende voorbeeld */
        /* http://localhost:49164/api/country/9 */
        //[HttpGet("{id}", Name = "Get")]
        //public IActionResult Get(int id) {
        //    try {

        //        return Ok(repo.GetCountry(id));

        //    } catch (CountryException ex) {

        //        return NotFound();
        //    }
        //}

        /*Same as above but if you want to give extra message Note: its to check the >5 id which doesnt exist*/
        /*http://localhost:49164/api/country/9 */
        //[HttpGet("{id}", Name = "Get")]
        //public IActionResult Get(int id) {
        //    try {

        //        return Ok(repo.GetCountry(id));

        //    } catch (CountryException ex) {

        //        return NotFound(ex.Message);
        //    }
        //}

        /* HEADEen HEAD request lijkt op een GET request maar geeft enkel de headers terug en niet de body.
         * Deze requestwordt  voornamelijk  gebruikt  om  te  kijken  of  een bepaalde  request  een bestaand 
         * antwoord zal geven(zonder de eigenlijke data op te vragen).We kunnen hiermee bijvoorbeeld controleren
         * of een  bepaalde  bron  bestaat,  wat  interessant  kan  zijn  als  het  bijvoorbeeld  over  een  grote
         * bron  gaataangezien het HEAD verzoek dan een stuk sneller zal zijn dan het GET verzoek.HEAD requests 
         * kunnen ook interessant zijn voor cashing, indien het document is aangepast (vb LastModified/ContentLength
         * header info is anders) kan een nieuwe versie worden afgehaald.In code is het vrij 
         * eenvoudig om een HEAD request toe te voegen, we hoeven enkel een extra annotatie toe te voegen. */
        /* http://localhost:49164/api/country/9 */
        //[HttpGet]
        //[HttpHead]
        //public IEnumerable<Country> Get() {
        //    return repo.GetAll();
        //}

        //[HttpGet("{id}")]
        //[HttpHead("{id}")]
        //public IActionResult Get(int id) {
        //    try {

        //        return Ok(repo.GetCountry(id));

        //    } catch (CountryException ex) {

        //        return NotFound(ex.Message);
        //    }
        //}

        /* Filtering and Searching
         if you dont want to select all the country but some of them you can use search and filter
        Here we filter the continent*/
        /*http://localhost:49164/api/country?Continent=Zuid-Amerika */
        //Get: api/Country
        //[HttpGet]
        //[HttpHead]
        //public IEnumerable<Country> Getall([FromQuery] string continent) {
        //    if (!string.IsNullOrWhiteSpace(continent))
        //        return repo.GetAll(continent);
        //    else
        //        return repo.GetAll();
        //}

        /*http://localhost:49164/api/country?Continent=Europa&Capital=Oslo */
        [HttpGet]
        [HttpHead]
        public IEnumerable<Country> Getall([FromQuery] string continent, [FromQuery] string capital) {
            if (!string.IsNullOrWhiteSpace(continent)) {
                if (!string.IsNullOrWhiteSpace(capital.Trim())) 
                    return repo.GetAll(continent, capital);
                else
                        return repo.GetAll(continent);
                } else
                    return repo.GetAll();
        }


    }
}
