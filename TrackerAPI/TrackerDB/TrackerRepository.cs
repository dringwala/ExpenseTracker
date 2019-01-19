using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TrackerDB.Entities;

namespace TrackerDB
{
    public class TrackerRepository :ITrackerRepository
    {
        TrackerDbContext _ctx;
        public TrackerRepository(TrackerDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Bank> GetAllBanks()
        {
            return _ctx.Banks;
        }

        public IQueryable<TransactionCategory> GetAllTransactionCategories()
        {
            return _ctx.TransactionCategories;
        }

        public IQueryable<Transaction> GetUserTransactions(string userName)
        {
            return _ctx.Transactions.Include("Account")
                                    .Where(t=> t.Account.UserName.Equals(userName));
        }

        public IQueryable<Account> GetUserAccounts(string userName)
        {
            return _ctx.Accounts.Where(a => a.UserName.Equals(userName));
        }

        public IQueryable<Transaction> GetAccountTransactions(string userName, long accountID)
        {
            return GetUserTransactions(userName).Where(t => t.Account.Id == accountID);
        }

       public Bank GetBank(long id)
        {
            return _ctx.Banks.Where(bank => bank.Id == id).FirstOrDefault();
        }

        public bool Insert (Bank bank)
        {
            try
            {
                if (_ctx.Banks.Any(_ => _.Name.Equals(bank.Name, StringComparison.InvariantCultureIgnoreCase)))
                    return false;
                _ctx.Banks.Add(bank);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Bank bank)
        {
            return UpdateEntity(_ctx.Banks, bank);
        }

        public bool Update(TransactionCategory category)
        {
            return UpdateEntity(_ctx.TransactionCategories, category);
        }

        public bool DeleteBank(long id)
        {
            try {
                var entity = _ctx.Banks.Where(b => b.Id == id).FirstOrDefault();
                if(entity != null)
                {
                    _ctx.Banks.Remove(entity);
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        private bool UpdateEntity<T>(DbSet<T> dbSet, T entity) where T: class
        {
            try {
                dbSet.AttachAsModified(entity, _ctx);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}

