using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading.Tasks;
using LandingApi.DataAccess.Repositories.Interfaces;
using LandingApi.Extensions;
using LandingApi.Models;
using LandingApi.Models.Enums;
using LandingApi.ViewModels;
using Microsoft.Extensions.Logging;

namespace LandingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILogger<LeadController> _logger;
        private readonly IClientRepository _clientRepository;

        public LeadController(ILogger<LeadController> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var returnedData = _clientRepository.Get();

            return Ok(returnedData);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ClientViewModel client)
        {
            try
            {
                string dateFormat = "yyyy-MM-dd";
                DateTime dateValue;

                if (!DateTime.TryParseExact(client.Birthday.Encoded(), dateFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.AllowLeadingWhite, out dateValue))
                {
                    throw new Exception($"Date in wrong format. Try '{dateFormat}'.");
                }

                var clientData = new Client
                {
                    Email = client.Email.Encoded(),
                    FirstName = client.FirstName.Encoded(),
                    LastName = client.LastName.Encoded(),
                    ClientType = ClientTypeEnum.Lead,
                    PhoneNumber = client.PhoneNumber.Encoded(),
                    Birthday = dateValue
                };

                var clientResult = await _clientRepository.AddAsync(clientData);
                
                return Ok(clientResult);
            }
            catch (Exception e)
            {
                return NotFound(new { msg = e.Message });
            }
        }
    }
}
