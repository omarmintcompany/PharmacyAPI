using PharmacyAPI.Persistence;

namespace PharmacyAPI.Repositories
{
    public class BaseRepository
    {
        protected readonly PharmacyContext _context;
        public BaseRepository(PharmacyContext context)
        {
            _context = context;
        }
    }
}
