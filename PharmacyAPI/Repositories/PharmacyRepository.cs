using PharmacyAPI.Models.Repositories;
using PharmacyAPI.Persistence;
using PharmacyAPI.Resources;

namespace PharmacyAPI.Repositories
{
    public class PharmacyRepository : BaseRepository, IPharmacyRepository
    {

        public PharmacyRepository(PharmacyContext context) : base(context) { }


        public Pharmacys? GetPharmacy(PharmacyResource pharmacyResource)
        {
            return _context.Pharmacys.Where(x => x.PharmacyName == pharmacyResource.Name && x.Latitude == pharmacyResource.Latitude && x.Longitude == pharmacyResource.Latitude).FirstOrDefault();
        }
    }
}
