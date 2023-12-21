using PharmacyAPI.Models.Responses;
using PharmacyAPI.Resources;

namespace PharmacyAPI.Models.Services
{
    public interface IPharmacyService
    {
      //  Task<PharmacyResponse> GetPharmacy(int pharmacyId);
        Task<PharmacyResponse> CreatePharmacy(PharmacyResource pharmacyData);                 
        //Task<PharmacyResource> GetNearestPharmacy(int latitude, int longitude);
    }
}
