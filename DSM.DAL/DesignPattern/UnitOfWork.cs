using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Threading.Tasks;

namespace DSM.DAL
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        #region Fields

        bool _IsDisposed = false;

        public UnitOfWork(T DSMDBContext) => this.DSMDBContext = DSMDBContext;

        #endregion

        #region Props

        public T DSMDBContext { get; }
        public IDbContextTransaction DbContextTransaction { get; set; }

        public bool IsDisposed { get => _IsDisposed; }

        #endregion

        #region Methods

        public virtual void Commit() => DSMDBContext.Database.CurrentTransaction.Commit();

        public bool SaveChanges()
        {
            try
            {
                return DSMDBContext.SaveChanges() >= 0;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await DSMDBContext.SaveChangesAsync()) > 0;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            DSMDBContext.Dispose();
            _IsDisposed = true;
        }
        #endregion
    }

}
