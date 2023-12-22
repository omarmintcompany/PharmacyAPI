using PharmacyAPI.Models.Responses;
using PharmacyAPI.Persistence;
using PharmacyAPI.Resources;

namespace PharmacyAPI.Models.Repositories
{
    public interface IPharmacyRepository
    {
        Task<List<Pharmacys>> GetPharmacysList();
        Task<Pharmacys?> GetPharmacy(int  pharmacyId);
        Pharmacys? checkPharmacy(PharmacyResource pharmacyData);
        Task<Pharmacys> Add(Pharmacys pharmacyData);
        
    }
}
