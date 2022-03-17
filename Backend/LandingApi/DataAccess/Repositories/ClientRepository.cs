using LandingApi.DataAccess.Context;
using LandingApi.DataAccess.Repositories.Interfaces;
using LandingApi.Models;

namespace LandingApi.DataAccess.Repositories
{
    public class ClientRepository: Repository<Client>, IClientRepository
    {
        public ClientRepository(CampaignContext userCampaignContext) : base(userCampaignContext)
        {
        }
    }
}