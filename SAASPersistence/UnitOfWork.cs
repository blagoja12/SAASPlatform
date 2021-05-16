using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SAASPersistence.DataContext;

namespace AS.eJP.Data
{
    public partial class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext context;
        private Dictionary<string, object> repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (this.repositories == null)
            {
                this.repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (this.repositories.ContainsKey(type)) return (Repository<T>)this.repositories[type];

            var repositoryType = typeof(Repository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), this.context);
            this.repositories.Add(type, repositoryInstance);

            return (Repository<T>)this.repositories[type];
        }

        public virtual void EntityStateModified(object T)
        {
            this.context.Entry(T).State = EntityState.Modified;
        }


        public void SaveChanges()
        {
            var res = this.context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
