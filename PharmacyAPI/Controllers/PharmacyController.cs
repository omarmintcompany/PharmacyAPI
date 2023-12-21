using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Models.Services;
using PharmacyAPI.Resources;
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

        [HttpPost("add")]
        [ProducesResponseType(typeof(PharmacyResource), 200)]
        public async Task<IActionResult> createPharmacy([FromBody] PharmacyResource pharmacyData)
        {
            var result = await _pharmacyService.CreatePharmacy(pharmacyData);
            if (result.Success)
                return Ok(result.Resource);
            return BadRequest(result.Message);
        }

    }
}
