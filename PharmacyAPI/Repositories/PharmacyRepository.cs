using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Models.Repositories;
using PharmacyAPI.Persistence;
using PharmacyAPI.Resources;

namespace PharmacyAPI.Repositories
{
    public class PharmacyRepository : BaseRepository, IPharmacyRepository
    {

        public PharmacyRepository(PharmacyContext context) : base(context) { }

        public async Task<List<Pharmacys>> GetPharmacysList() 
        { 
            return _context.Pharmacys.ToList();
        }

        public async Task<Pharmacys?> GetPharmacy(int pharmacyId)
        {
            IQueryable<Pharmacys> query = _context.Pharmacys.Where(t => t.Id == pharmacyId);

            return await query.FirstOrDefaultAsync();
        }

        public Pharmacys? checkPharmacy(PharmacyResource pharmacyResource)
        {
            return _context.Pharmacys.Where(x => x.PharmacyName == pharmacyResource.Name && x.Latitude == pharmacyResource.Latitude && x.Longitude == pharmacyResource.Longitude).FirstOrDefault();
        }

        public async Task<Pharmacys> Add(Pharmacys pharmacyData)
        {
            await _context.AddAsync(pharmacyData);
            return pharmacyData;
        }
    }
}
