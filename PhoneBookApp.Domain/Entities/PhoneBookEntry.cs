namespace PhoneBookApp.Domain.Entities
{
    public class PhoneBookEntry
    {
        public string PhoneNumber { get; set; }
        public string PersonName { get; set; }

        public PhoneBookEntry(string personName, string phoneNumber)
        {
            PersonName = personName;
            PhoneNumber = phoneNumber;
        }
    }
}
