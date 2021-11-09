using BusinessLayer.Model;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTlayer.Mappers;
using RESTlayer.Model.input;
using RESTlayer.Model.output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTlayer.Controllers
{
    [Route("api/[controller]/gemeente")]
    [ApiController]
    public class AdresbeheerController : ControllerBase
    {
        private string url = "http://localhost:5000";
        private GemeenteService gemeenteService;
        private StraatService straatService;
        private AdresService adresService;

        public AdresbeheerController(GemeenteService gemeenteService,StraatService straatService,AdresService adresService)
        {
            this.gemeenteService = gemeenteService;
            this.straatService = straatService;
            this.adresService = adresService;
        }
        #region gemeente
        [HttpGet("{id}")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int id)
        {
            try
            {
                Gemeente gemeente = gemeenteService.GeefGemeente(id);
                return Ok(MapFromDomain.MapFromGemeenteDomain(url,gemeente,straatService));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<GemeenteRESToutputDTO> PostGemeente([FromBody] GemeenteRESTinputDTO restDTO)
        {
            try
            {
                Gemeente gemeente = gemeenteService.VoegGemeenteToe(MapToDomain.MapToGemeenteDomain(restDTO));
                return CreatedAtAction(nameof(GetGemeente), new { id = gemeente.NIScode },
                    MapFromDomain.MapFromGemeenteDomain(url, gemeente, straatService));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{gemeenteId}")]
        public IActionResult DeleteGemeente(int gemeenteId)
        {
            try
            {
                gemeenteService.VerwijderGemeente(gemeenteId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{gemeenteId}")]
        public IActionResult PutGemeente(int gemeenteId, [FromBody] GemeenteRESTinputDTO restDTO)
        {
            try
            {
                if (gemeenteId != restDTO.NIScode)
                {
                    return BadRequest();
                }
                if (gemeenteService.BestaatGemeente(gemeenteId))
                {
                    Gemeente gemeente = gemeenteService.UpdateGemeente(MapToDomain.MapToGemeenteDomain(restDTO));
                    return CreatedAtAction(nameof(GetGemeente), new { id = restDTO.NIScode }, MapFromDomain.MapFromGemeenteDomain(url, gemeente, straatService));
                }
                else
                {
                    return BadRequest("Gemeente bestaat niet");
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
        #region straten
        [HttpGet]
        [Route("{gemeenteId}/straat/{straatId}")]
        public ActionResult<StraatRESToutputDTO> GetStraat(int gemeenteId, int straatId)
        {
            try
            {
                Straat straat = straatService.GeefStraat(straatId);
                if (straat.Gemeente.NIScode != gemeenteId) return BadRequest("Gemeentecode klopt niet met url");
                return Ok(MapFromDomain.MapFromStraatDomain(url, straat, adresService));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
        #region adres
        #endregion
    }
}
