using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace E.Common.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// IDbContextTransaction ile _context için transaction 
        /// başlar savechanges durumunda commit olur ve transaction yeniden başlar
        /// </summary>
        private DbContext _context;
        private IDbContextTransaction _transaction;
            public UnitOfWork(DbContext context)
        {
            if (context == null)
            {
                throw new Exception("NullDbContextException");
            }
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }
        public void Dispose()
        {
            try
            {
                _context.Dispose();
            }
            catch (Exception ex)
            {

                //Hatalar Loglanabilir
            }             
        }
        public bool SaveChanges()
        {
            bool resultOfSaveChanges = false;
            try
            {
                
                _context.SaveChanges();
                _transaction.Commit();
                resultOfSaveChanges =true;

            }
            catch (Exception ex)
            {

                _transaction.Rollback();
                resultOfSaveChanges = false;
                //Hatalar Loglanabilir

            }
            finally {

                _transaction.Dispose();
                _transaction = _context.Database.BeginTransaction();
            }
            return resultOfSaveChanges;
        }
    }
}
