using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LandingApi.DataAccess.Repositories.Interfaces;
using LandingApi.Extensions;
using LandingApi.Models;
using LandingApi.Models.Enums;
using LandingApi.ViewModels;
using Microsoft.AspNetCore.Cors;
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
        public async Task<IActionResult> Get()
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
                DateTime.TryParseExact(client.Birthday.Encoded(), dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.AllowLeadingWhite, out dateValue);

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
                return NotFound(e);
            }
        }
    }
}
