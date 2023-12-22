using PharmacyAPI.Models.Responses;
using PharmacyAPI.Resources;
using PharmacyAPI.Resources.Query;

namespace PharmacyAPI.Models.Services
{
    public interface IPharmacyService
    {
        Task<PharmacyResponse> GetPharmacy(int pharmacyId);
        Task<PharmacyResponse> CreatePharmacy(PharmacyResource pharmacyData);                 
        Task<PharmacyResponse> GetNearestPharmacy(PharmacyListQuery pharmacyListQuery);
    }
}
