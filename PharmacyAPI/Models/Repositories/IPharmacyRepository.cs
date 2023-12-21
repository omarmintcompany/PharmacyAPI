using PharmacyAPI.Persistence;
using PharmacyAPI.Resources;

namespace PharmacyAPI.Models.Repositories
{
    public interface IPharmacyRepository
    {
        Pharmacys? GetPharmacy(PharmacyResource pharmacyResource);
    }
}
