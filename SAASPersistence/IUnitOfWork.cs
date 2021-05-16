

namespace AS.eJP.Data
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;

        void SaveChanges();

        void EntityStateModified(object T);

        void Dispose();

    }
}
