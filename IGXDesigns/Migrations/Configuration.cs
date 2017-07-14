namespace IGXDesigns.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IGXDesigns.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<IGXDesigns.Models.ProjectDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IGXDesigns.Models.ProjectDBContext";
        }

        protected override void Seed(IGXDesigns.Models.ProjectDBContext context)
        {
            context.Project.AddOrUpdate(i => i.Name,
                   new Project
                   {
                       Name = "Ingeniux",
                       GitLinkText = "Nah",
                       GitLink = "https://github.com/",
                       LiveLink = "https://www.ingeniux.com/",
                       Designer = "Desiigner"
                   }
            );




        }
    }
}
