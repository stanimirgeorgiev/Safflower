namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialNetwork.Data.SocialNetworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = false;
            AutomaticMigrationsEnabled = true;
            ContextKey = "SocialNetwork.Data.SocialNetworkContext";
        }

        protected override void Seed(SocialNetwork.Data.SocialNetworkContext context)
        {
        }
    }
}
