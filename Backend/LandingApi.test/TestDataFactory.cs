using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using LandingApi.Models;
using LandingApi.Models.Enums;
using LandingApi.ViewModels;

namespace LandingApi.test
{
    public class TestDataFactory
    {
        public static Client CreateClient()
        {
            var random = RandomNumberGenerator.GetInt32(100);
            var client = new Client
            {
                ClientType = ClientTypeEnum.Lead,
                Email = $"Teste{random}@domain{random}.com",
                FirstName = "Test",
                LastName = random.ToString(),
                PhoneNumber = $"+351 {random}",
                Birthday = DateTime.UtcNow
            };
            
            return client;
        }

        public static ClientViewModel CreateClientViewModel()
        {
            var random = RandomNumberGenerator.GetInt32(100);
            var client = new ClientViewModel
            {
                Email = $"Teste{random}@domain{random}.com",
                FirstName = "Test",
                LastName = $"tester{random}",
                PhoneNumber = $"+351 {random}",
                Birthday = "1985-06-03"
            };

            return client;
        }

        public static Dictionary<string, string> CreateClientAsDictionary()
        {
            var client = CreateClientViewModel();

            return new Dictionary<string, string>
            {
                { "Email", client.Email},
                { "FirstName", client.FirstName },
                { "LastName", client.LastName },
                { "PhoneNumber", client.PhoneNumber },
                { "Birthday", client.Birthday },
            };
        }

    }
}