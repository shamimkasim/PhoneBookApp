using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Application.Interfaces;
using PhoneBookApp.Application.Services;

namespace PhoneBookApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            this.phoneBookService = phoneBookService;
        }
        [HttpGet]
        public IActionResult GetAllEntries()
        {
            var entries = phoneBookService.GetAllEntries();
            return Ok(entries);
        }
        [HttpGet("{personName}")]
        public IActionResult GetPhoneNumberByPersonName(string personName)
        {
            var phoneBookEntry = phoneBookService.GetPhoneNumberByPersonName(personName);

            if (phoneBookEntry == null)
                return NotFound();

            return Ok(phoneBookEntry);
        }

    }

}
