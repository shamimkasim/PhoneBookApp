using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Application.Interfaces;

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
