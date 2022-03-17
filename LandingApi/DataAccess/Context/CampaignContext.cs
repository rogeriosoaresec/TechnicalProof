using System.Linq;
using LandingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LandingApi.DataAccess.Context
{
    public class CampaignContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public CampaignContext(DbContextOptions options) : base(options)
        {

        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

	}
}