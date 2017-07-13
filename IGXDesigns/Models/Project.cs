using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace IGXDesigns.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LiveLink { get; set; }
        public string GitLink { get; set; }
        public string GitLinkText { get; set; }



    }

    public class ProjectDBContext : DbContext
    {
        public DbSet<Project> Project { get; set; }
    }

}