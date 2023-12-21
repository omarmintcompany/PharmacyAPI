using PharmacyAPI.Persistence;
using PharmacyAPI.Resources;

namespace PharmacyAPI.Models.Responses
{
    public class PharmacyResponse : BaseResponse<PharmacyResource>
    {
        private Pharmacys newPharmacy;

        public PharmacyResponse(PharmacyResource data) : base(data) { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PharmacyResponse(string message) : base(message) { }

    }
}
