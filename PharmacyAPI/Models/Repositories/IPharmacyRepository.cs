using PharmacyAPI.Persistence;
using PharmacyAPI.Resources;

namespace PharmacyAPI.Models.Repositories
{
    public interface IPharmacyRepository
    {
        Pharmacys? GetPharmacy(int  pharmacyId);
        Pharmacys? checkPharmacy(PharmacyResource pharmacyData);
        Task<Pharmacys> Add(Pharmacys pharmacyData);
    }
}
