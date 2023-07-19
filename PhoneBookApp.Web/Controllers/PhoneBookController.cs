using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhoneBookApp.Domain.Entities;

namespace PhoneBookApp.Web.Controllers
{

    public class PhoneBookController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public PhoneBookController()
        {
            _apiBaseUrl = "https://localhost:7096";
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index(string personName)
        {
            if (string.IsNullOrEmpty(personName))
            {
                return View();
            }

            var phoneBookEntry = await GetPhoneNumberByPersonNameFromApi(personName);

            if (phoneBookEntry == null)
            {
                ViewBag.Message = $"No phone number found for {personName}.";
                return View();
            }

            return View(phoneBookEntry);
        }

        private async Task<PhoneBookEntry> GetPhoneNumberByPersonNameFromApi(string personName)
        {
            var apiUrl = $"{_apiBaseUrl}/api/PhoneBook/{personName}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var phoneBookEntry = JsonConvert.DeserializeObject<PhoneBookEntry>(json);
                return phoneBookEntry;
            }

            return null;
        }
    }
}
