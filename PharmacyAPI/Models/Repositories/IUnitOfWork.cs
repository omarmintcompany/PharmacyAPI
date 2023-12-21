namespace PharmacyAPI.Models.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        void BeginTransaction();
        void Commit();
        void Rollback();
        void DetachAll();
    }

}
