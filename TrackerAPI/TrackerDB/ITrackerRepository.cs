using System.Linq;
using TrackerDB.Entities;

namespace TrackerDB
{
    public interface ITrackerRepository
    {
        #region Banks
        IQueryable<Bank> GetAllBanks();
        Bank GetBank(long id);
        Bank GetBankByName(string bankName);
        bool Insert(Bank bank);
        bool Update(Bank bank);
        bool DeleteBank(long id);
        #endregion
        #region Account
        IQueryable<Account> GetAllAccountsByUser(long userName);
        Account GetAccountByIdAndUser(long id, long userName);
        Account GetAccountByNameAndUser(string accountName, long userName);
        bool Insert(Account account);
        bool Update(Account account);
        bool DeleteAccount(long id, long userName);
        #endregion

        #region Transactions
        IQueryable<Transaction> GetAllTransactionsByUser(long userName);
        Transaction GetTransactionByIdAndUser(long id, long userName);
        Transaction GetTransactionByStoreAndUser(string storeName, long userName);
        bool Insert(Transaction transaction);
        bool Update(Transaction transaction);
        bool DeleteTransaction(long id, long userName);
        #endregion


        bool SaveAll();

    }
}