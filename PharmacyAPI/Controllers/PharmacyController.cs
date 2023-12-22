using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Models.Responses;
using PharmacyAPI.Models.Services;
using PharmacyAPI.Resources;
using PharmacyAPI.Resources.Query;
using PharmacyAPI.Services;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class PharmacyController : Controller
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        /// <summary>
        /// Obtiene una farmacia por ID.
        /// </summary>
        /// <param name="pharmacyId">ID de la ficha de la farmacia.</param>
        /// <returns>La farmacia correspondiente al ID.</returns>

        [HttpGet("farmacia/ver/{phamacyId}")]
        [ProducesResponseType(typeof(PharmacyResource), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetPharmacy(int phamacyId)
        {

            PharmacyResponse pharmacyData = await _pharmacyService.GetPharmacy(phamacyId);
            if (pharmacyData.Success)
                return Ok(pharmacyData.Resource);
            return BadRequest(pharmacyData.Message);
        }

        /// <summary>
        /// Crea una nueva farmacia siempre que no exista según su nombre y geolocalización.
        /// </summary>
        /// <param name="pharmacyData">Datos de la nuva farmacia.</param>
        /// <returns>La farmacia creada.</returns>
        [HttpPost("farmacia/agregar")]
        [ProducesResponseType(typeof(PharmacyResource), 200)]
        public async Task<IActionResult> createPharmacy([FromBody] PharmacyResource pharmacyData)
        {
            var result = await _pharmacyService.CreatePharmacy(pharmacyData);
            if (result.Success)
                return Ok(result.Resource);
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Localiza la farmacia más cercana según la geolocalización del solicitante.
        /// </summary>
        /// <param name="pharmacyListQuery">Coordenadas de latitud y longitud del cliente.</param>
        /// <returns>Datos de la farmacia mas cercana.</returns>
        [HttpGet("farmacia/")]
        [ProducesResponseType(typeof(PharmacyResource), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetNearestPharmacy([FromQuery] PharmacyListQuery pharmacyListQuery)
        {
            PharmacyResponse pharmacyData = await _pharmacyService.GetNearestPharmacy(pharmacyListQuery);
            if (pharmacyData.Success)
                return Ok(pharmacyData.Resource);
            return BadRequest(pharmacyData.Message);
        }

    }
}
