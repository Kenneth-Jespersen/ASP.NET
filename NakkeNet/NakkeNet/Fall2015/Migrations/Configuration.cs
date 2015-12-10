using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NakkeNet.Models;

namespace NakkeNet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NakkeNet.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "NakkeNet.Models.ApplicationDbContext";
        }

        protected override void Seed(NakkeNet.Models.ApplicationDbContext context)
        {
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            rm.Create(new IdentityRole("Admin"));
            rm.Create(new IdentityRole("User"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //create an object of the ApplicationUser and provide a username
            var client1 = new ApplicationUser { UserName = "Admin@Nakke.net" };

            //Add the client1 object to the database through the usermanager (and supply password).
            var result1 = userManager.Create(client1, Secrets.Password);

            //If that does not go well (username could already exist), look up the user instead.
            if (result1.Succeeded == false)
            {
                client1 = userManager.FindByName("Admin@Nakke.net");
            }

            //save this change to the database to get the GUID that is used as an Id.
            context.SaveChanges();

            //Now when creating new users you can use this value.

            //Add the following to Student
            //UserId = client.Id

            userManager.AddToRole(client1.Id, "Admin");

            //  This method will be called after migrating to the latest version.

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

            context.Users.AddOrUpdate(s => s.Email, new User[]
{
                    new User
                    {
                        Firstname = "Kenneth",
                        Lastname =  "Jespersen",
                        Email = "kennethjespersen88@gmail.com",
                        MobilePhone = "12345678",
                        ProfileImagePath = "/ProfileImages/094f03f7-eb3f-47c7-85d8-78a62ac5dd1b.jpg" //requires the image to be located here
		            },
                    new User
                    {
                        Firstname = "Casper",
                        Lastname = "Vejdiksen",
                        Email = "cvejdiksen@gmail.com",
                        MobilePhone = "12345678",
                        ProfileImagePath = "/ProfileImages/094f03f7-eb3f-47c7-85d8-78a62ac5dd1b.jpg"
                    },
                    new User
                    {
                        Firstname = "Hans",
                        Lastname = "Hansen",
                        Email = "hans@hans.dk",
                        MobilePhone = "12345678",
                        ProfileImagePath = "/ProfileImages/094f03f7-eb3f-47c7-85d8-78a62ac5dd1b.jpg"
                    },
                    new User
                    {
                        Firstname = "Jens",
                        Lastname = "Jensen",
                        Email = "jens@jens.dk",
                        MobilePhone = "12345638",
                        ProfileImagePath = "/ProfileImages/094f03f7-eb3f-47c7-85d8-78a62ac5dd1b.jpg"
                    },
                    new User
                    {
                        Firstname = "Helle",
                        Lastname = "Hellesen",
                        Email = "helle@helle.dk",
                        MobilePhone = "12345632",
                        ProfileImagePath = "/ProfileImages/094f03f7-eb3f-47c7-85d8-78a62ac5dd1b.jpg"
                    },
                    new User
                    {
                        Firstname = "Berit",
                        Lastname = "Beritsen",
                        Email = "berit@berit.dk",
                        MobilePhone = "12345631",
                        ProfileImagePath = "/ProfileImages/094f03f7-eb3f-47c7-85d8-78a62ac5dd1b.jpg"
                    },
                    new User
                    {
                        Firstname = "Allan",
                        Lastname = "Allansen",
                        Email = "allan@allan.dk",
                        MobilePhone = "12345632",
                        ProfileImagePath = "/ProfileImages/094f03f7-eb3f-47c7-85d8-78a62ac5dd1b.jpg"
                    },
                    new User
                    {
                        Firstname = "Jesper",
                        Lastname = "Jespersen",
                        Email = "jesper@jesper.dk",
                        MobilePhone = "12315631",
                        ProfileImagePath = "/ProfileImages/094f03f7-eb3f-47c7-85d8-78a62ac5dd1b.jpg"
                    }
});

            context.CompetencyHeaders.AddOrUpdate(h => h.CompetencyHeaderId, new CompetencyHeader[]
            {
            new CompetencyHeader
            {
                CompetencyHeaderId = 1,
                Name = "Områdeleder"
            },
            new CompetencyHeader
            {
                CompetencyHeaderId = 2,
                Name = "Floorleder"
            },

            new CompetencyHeader
            {
                CompetencyHeaderId = 3,
                Name = "Medarbejder"
            },
            new CompetencyHeader
            {
                CompetencyHeaderId = 4,
                Name = "Frivillig"
            }
            });




            context.Competencies.AddOrUpdate(c => c.CompetencyId, new Competency[]
        {
            new Competency
                {
                    CompetencyId = 1,
                    CompetencyHeaderId = 3,
                    Name="Backstage"
                },
                new Competency{
                    CompetencyId = 2,
                    CompetencyHeaderId = 3,
                    Name="Baren"
                },
                new Competency
                {
                    CompetencyId = 3,
                    CompetencyHeaderId = 3,
                    Name="Det lumre køkken"
                },
                new Competency
                {
                    CompetencyId = 4,
                    CompetencyHeaderId = 3,
                    Name="Forplejning"
                },
                new Competency
                {
                    CompetencyId = 5,
                    CompetencyHeaderId = 3,
                    Name="Fotograf"
                },
                new Competency
                {
                    CompetencyId = 6,
                    CompetencyHeaderId = 3,
                    Name="Frivilligkorps"
                },
                new Competency
                {
                    CompetencyId = 7,
                    CompetencyHeaderId = 3,
                    Name="Indgang"
                },
                new Competency
                {
                    CompetencyId = 8,
                    CompetencyHeaderId = 3,
                    Name="Kiosken"
                },
                new Competency
                {
                    CompetencyId = 9,
                    CompetencyHeaderId = 3,
                    Name="Krea"
                },
                new Competency
                {
                    CompetencyId = 10,
                    CompetencyHeaderId = 3,
                    Name="Nurser"
                },
                new Competency
                {
                    CompetencyId = 11,
                    CompetencyHeaderId = 3,
                    Name="Pølsebod"
                },
                new Competency
                {
                    CompetencyId = 12,
                    CompetencyHeaderId = 3,
                    Name="Samarit"
                },
                new Competency
                {
                    CompetencyId = 13,
                    CompetencyHeaderId = 3,
                    Name="Sikkerhed"
                },
                new Competency
                {
                    CompetencyId = 14,
                    CompetencyHeaderId = 3,
                    Name="Økonomi"
                }
        });

        }
    }
}
