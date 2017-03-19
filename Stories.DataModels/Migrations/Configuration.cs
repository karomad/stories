namespace Stories.DataModels.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Stories.DataModels.Entities.StoriesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Stories.DataModels.Entities.StoriesDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            var users = new User[]
              { new User { Id = 1, Name = "Karo" },
                new User { Id = 2, Name = "Ani" },
                new User { Id = 3, Name = "Areg" },
                new User { Id = 4, Name = "Hovo" },
                new User { Id = 5, Name = "Vahe" },
                new User { Id = 6, Name = "Anna" }
              };
            var stories = new Story[]
            {
                new Story { Id = 1, Title = "Story for 1", Description = "Description for story 1", PostedOn = new DateTime(2017, 3, 20), UserId = 1 },
                new Story { Id = 2, Title = "Story  for  2", Description = "Description for story 2", PostedOn = new DateTime(2017, 3, 20), UserId = 2 },
                new Story { Id = 3, Title = "Story  for 3", Description = "Description for story 3", PostedOn = new DateTime(2017, 3, 20), UserId = 3 },
                new Story { Id = 4, Title = "Story  for 4", Description = "Description for story 4", PostedOn = new DateTime(2017, 3, 20), UserId = 4 },
                new Story { Id = 5, Title = "Story  for 5", Description = "Description for story 5", PostedOn = new DateTime(2017, 3, 20), UserId = 5 },
                new Story { Id = 6, Title = "Story  for 6", Description = "Description for story 6", PostedOn = new DateTime(2017, 3, 20), UserId = 6 },
                new Story { Id = 7, Title = "Story  for 7", Description = "Description for story 7", PostedOn = new DateTime(2017, 3, 20), UserId = 2 },
                new Story { Id = 8, Title = "Story  for 8", Description = "Description for story 8", PostedOn = new DateTime(2017, 3, 20), UserId = 5 },
                new Story { Id = 9, Title = "Story  for 9", Description = "Description for story 9", PostedOn = new DateTime(2017, 3, 20), UserId = 3 },
                new Story { Id = 10, Title = "Story for  10", Description = "Description for story 10", PostedOn = new DateTime(2017, 3, 20), UserId = 2 },
                new Story { Id = 11, Title = "Story for  11", Description = "Description for story 11", PostedOn = new DateTime(2017, 3, 20), UserId = 2 },
                new Story { Id = 12, Title = "Story  for 12", Description = "Description for story 12", PostedOn = new DateTime(2017, 3, 20), UserId = 3 },
                new Story { Id = 13, Title = "Story  for 13", Description = "Description for story 13", PostedOn = new DateTime(2017, 3, 20), UserId = 4 },
                new Story { Id = 14, Title = "Story for  14", Description = "Description for story 14", PostedOn = new DateTime(2017, 3, 20), UserId = 5 },
                new Story { Id = 15, Title = "Story for  15", Description = "Description for story 15", PostedOn = new DateTime(2017, 3, 20), UserId = 1 },
                new Story { Id = 16, Title = "Story  for 16", Description = "Description for story 16", PostedOn = new DateTime(2017, 3, 20), UserId = 1 },
                new Story { Id = 17, Title = "Story for  17", Description = "Description for story 17", PostedOn = new DateTime(2017, 3, 20), UserId = 6 },
                new Story { Id = 18, Title = "Story for  18", Description = "Description for story 18", PostedOn = new DateTime(2017, 3, 20), UserId = 5 },
                new Story { Id = 19, Title = "Story for  19", Description = "Description for story 19", PostedOn = new DateTime(2017, 3, 20), UserId = 3 },
                new Story { Id = 20, Title = "Story for  20", Description = "Description for story 20", PostedOn = new DateTime(2017, 3, 20), UserId = 4 },
                new Story { Id = 21, Title = "Story  for 21", Description = "Description for story 21", PostedOn = new DateTime(2017, 3, 20), UserId = 6 }
            };


            context.Users.AddOrUpdate(x => x.Id, users);
            context.Stories.AddOrUpdate(x => x.Id, stories);
            context.Groups.AddOrUpdate(x => x.Id,
                new Group
                {
                    Id = 1,
                    Name = ".Net developers group",
                    Description = "Description",
                    Stories = new Story[]
                    {
                        stories[0],
                        stories[1],
                        stories[2],
                        stories[3],
                        stories[4],
                        stories[5],
                        stories[6],
                        stories[7],
                        stories[8],
                        stories[9],
                    },
                    Members = users
                },

                new Group
                {
                    Id = 2,
                    Name = ".Javascript developers group",
                    Description = "Description",
                    Stories = new Story[]
                    {
                        stories[10],
                        stories[11],
                        stories[12],
                        stories[13],
                        stories[14],
                        stories[15],
                        stories[16],
                        stories[17],
                        stories[18],
                        stories[19],
                    },
                    Members = users
                },
                  new Group
                  {
                      Id = 3,
                      Name = ".C developers group",
                      Description = "Description",
                      Stories = new Story[]
                    {
                        stories[20]
                    },
                      Members = users
                  });

            context.SaveChanges();
                
        }

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //

    }
}
