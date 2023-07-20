using PhoneBookApp.Domain.Entities;

namespace PhoneBookApp.Application.Interfaces
{
    public interface IPhoneBookRepository
    {        
        PhoneBookEntry GetPhoneNumberByPersonName(string personName);
        IEnumerable<PhoneBookEntry> GetPhoneBookEntries();
    }
}
