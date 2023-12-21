using PharmacyAPI.Models.Responses;
using PharmacyAPI.Resources;

namespace PharmacyAPI.Models.Services
{
    public interface IPharmacyService
    {
        Task<PharmacyResponse> CreatePharmacy(PharmacyResource pharmacyData);
        /* Task<PharmacyResponse> DeletePharmacy(int pharmacyId);
         Task<PharmacyResource> UpdatePharmacy(PharmacyResource pharmacyData);
         Task<PharmacyResource> GetNearestPharmacy(int latitude, int longitude);*/
    }
}
