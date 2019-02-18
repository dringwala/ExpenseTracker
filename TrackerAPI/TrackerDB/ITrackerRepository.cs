using System.Linq;
using TrackerDB.Entities;

namespace TrackerDB
{
    public interface ITrackerRepository
    {
        IQueryable<Bank> GetAllBanks();
        Bank GetBank(long id);
        Bank GetBankByName(string bankName);
        bool Insert(Bank bank);
        bool Update(Bank bank);
        bool DeleteBank(long id);
        bool SaveAll();

    }
}