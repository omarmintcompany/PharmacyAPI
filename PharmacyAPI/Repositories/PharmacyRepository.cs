using PharmacyAPI.Models.Repositories;
using PharmacyAPI.Persistence;
using PharmacyAPI.Resources;

namespace PharmacyAPI.Repositories
{
    public class PharmacyRepository : BaseRepository, IPharmacyRepository
    {

        public PharmacyRepository(PharmacyContext context) : base(context) { }


        public Pharmacys? GetPharmacy(int pharmacyId)
        {
            return _context.Pharmacys.Where(x => x.Id == pharmacyId).FirstOrDefault();
        }

        public Pharmacys? checkPharmacy(PharmacyResource pharmacyResource)
        {
            return _context.Pharmacys.Where(x => x.PharmacyName == pharmacyResource.Name && x.Latitude == pharmacyResource.Latitude && x.Longitude == pharmacyResource.Latitude).FirstOrDefault();
        }

        public async Task<Pharmacys> Add(Pharmacys pharmacyData)
        {
            await _context.AddAsync(pharmacyData);
            return pharmacyData;
        }
    }
}
