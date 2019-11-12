

namespace FilmProjects.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FilmProjectContext : DbContext
    {
        public FilmProjectContext()
            : base("name=FilmProjectContext")
        {
            Database.SetInitializer<FilmProjectContext>(new FilmProjectInitializer());
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProject> UserProjects { get; set; }
    }
}
