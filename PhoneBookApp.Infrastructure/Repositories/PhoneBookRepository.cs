using PhoneBookApp.Application.Interfaces;
using PhoneBookApp.Domain.Entities;

namespace PhoneBookApp.Infrastructure.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly List<PhoneBookEntry> _phoneBookEntries;

        public PhoneBookRepository(List<PhoneBookEntry> phoneBookEntries)
        {
            _phoneBookEntries = phoneBookEntries;
        }

        public PhoneBookEntry GetPhoneNumberByPersonName(string personName)
        {
            var phoneBookEntry = _phoneBookEntries.Find(entry => entry.PersonName == personName);
            if (phoneBookEntry == null)
            {
                throw new ArgumentException($"Phone number for person '{personName}' not found.");
            }
            return phoneBookEntry;
        }
        public IEnumerable<PhoneBookEntry> GetPhoneBookEntries()
        {
            return _phoneBookEntries;
        }

    }
}
