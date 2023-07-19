using PhoneBookApp.Application.Interfaces;
using PhoneBookApp.Domain.Entities;

namespace PhoneBookApp.Application.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        public PhoneBookService(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }    

        public PhoneBookEntry GetPhoneNumberByPersonName(string personName)
        {
            return _phoneBookRepository.GetPhoneNumberByPersonName(personName);
        }        
    }
}
