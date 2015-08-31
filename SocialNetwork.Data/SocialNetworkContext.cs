namespace SocialNetwork.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SocialNetwork.Models;
    using System.Data.Entity;
    using SocialNetwork.Data.Migrations;

    public class SocialNetworkContext : IdentityDbContext<User>
    {
        public SocialNetworkContext()
            : base("SocialNetworkContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SocialNetworkContext, Configuration>());
        }

        public static SocialNetworkContext Create()
        {
            return new SocialNetworkContext();
        }
    }
}
