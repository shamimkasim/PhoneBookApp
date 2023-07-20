using PhoneBookApp.Domain.Entities;

namespace PhoneBookApp.Application.Interfaces
{
    public interface IPhoneBookService
    {
        IEnumerable<PhoneBookEntry> GetAllEntries();
        PhoneBookEntry GetPhoneNumberByPersonName(string personName);       
    }
}
