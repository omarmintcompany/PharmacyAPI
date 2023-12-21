using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Models.Repositories;

namespace PharmacyAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly PharmacyContext _context;

        public UnitOfWork(PharmacyContext context)
        {
            _context = context;
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void DetachAll()
        {
            List<EntityEntry> entityEntries = _context.ChangeTracker.Entries().ToList();

            foreach (EntityEntry entityEntry in entityEntries)
            {
                entityEntry.State = EntityState.Detached;
            }
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
