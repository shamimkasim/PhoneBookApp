using PhoneBookApp.Domain.Entities;

namespace PhoneBookApp.Application.Interfaces
{
    public interface IPhoneBookService
    {
        PhoneBookEntry GetPhoneNumberByPersonName(string personName);       
    }
}
