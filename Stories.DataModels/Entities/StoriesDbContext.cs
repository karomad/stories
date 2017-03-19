namespace Stories.DataModels.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoriesDbContext : DbContext
    {
        public StoriesDbContext()
            : base("name=StoriesDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Story> Stories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(x => x.Stories)
                .WithMany(x => x.Groups)
                .Map(gs =>
                {
                    gs.MapLeftKey("GroupId");
                    gs.MapRightKey("StoryId");
                    gs.ToTable("GroupStories");
                });

            modelBuilder.Entity<Group>()
               .HasMany(x => x.Members)
               .WithMany(x => x.Groups)
               .Map(gs =>
               {
                   gs.MapLeftKey("GroupId");
                   gs.MapRightKey("UserId");
                   gs.ToTable("GroupUsers");
               });
        }
    }
}
