/* Developer:
 * James Camacho
 * 
 * File Name:
 * FilmProjectInitializer.cs
 * 
 * 
 * Main Functionality:
 * Initialize the database that holds all data from FilmProjects with static information.
 *
 * Version: 1.0
 * 
 * Last Edited : 11/9/19
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FilmProjects.Models
{
    public class FilmProjectInitializer : System.Data.Entity.DropCreateDatabaseAlways<FilmProjectContext>
    {
        /*
         * Function: 
         * IntializeDatabase
         * 
         * Input: 
         * Takes in a context of the project database.
         * 
         * Output: 
         * N/A
         * 
         * Functionality:
         * Intialize database by removing all information previosuly stored in database and making a new instance. 
         * 
         */
        public override void InitializeDatabase(FilmProjectContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        /*
         * Function: 
         * Seed 
         * 
         * Input: 
         * Takes in a context of the project database.
         * 
         * Output: 
         * N/A 
         * 
         * Functionality:
         * Fill in the context of the database will static information for each table. 
         * Update the database by saving the changes of the context.
         * 
         */
        protected override void Seed(FilmProjectContext context)
        {
            var users = new List<User>
            {
                new User{ UserId = 1, FirstName = "Leonardo", LastName = "DiCaprio"}, 
                new User{ UserId = 2, FirstName = "Mahershala", LastName="Ali" }, 
                new User{ UserId = 3, FirstName ="Benicio", LastName = "Del Toro" }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var projects = new List<Project>
            {
                new Project{ ProjectId = 1, StartDate= DateTime.Parse("2019-10-17"), EndDate =DateTime.Parse("2019-11-30"), Credits = 3  },
                new Project{ ProjectId = 2, StartDate= DateTime.Parse("2020-10-01"), EndDate =DateTime.Parse("2020-10-17"), Credits = 8  },
                new Project{ ProjectId = 3, StartDate= DateTime.Parse("2019-07-01"), EndDate =DateTime.Parse("2019-12-01"), Credits = 7  },
                new Project{ ProjectId = 4, StartDate= DateTime.Parse("2018-09-01"), EndDate =DateTime.Parse("2020-09-22"), Credits = 4  },
                new Project{ ProjectId = 5, StartDate= DateTime.Parse("2021-09-01"), EndDate =DateTime.Parse("2021-09-07"), Credits = 2  },
                new Project{ ProjectId = 6, StartDate= DateTime.Parse("2019-10-01"), EndDate =DateTime.Parse("2021-09-01"), Credits = 11  },
                new Project{ ProjectId = 7, StartDate= DateTime.Parse("2019-06-01"), EndDate =DateTime.Parse("2019-11-15"), Credits = 9  },
                new Project{ ProjectId = 8, StartDate= DateTime.Parse("2019-12-01"), EndDate =DateTime.Parse("2020-01-01"), Credits = 8  },
                new Project{ ProjectId = 9, StartDate= DateTime.Parse("2019-04-01"), EndDate =DateTime.Parse("2019-07-14"), Credits = 3  },
                new Project{ ProjectId = 10, StartDate= DateTime.Parse("2018-07-11"), EndDate =DateTime.Parse("2020-01-12"), Credits = 5  },
                new Project{ ProjectId = 11, StartDate= DateTime.Parse("2019-03-04"), EndDate =DateTime.Parse("2020-03-01"), Credits = 12  },
                new Project{ ProjectId = 12, StartDate= DateTime.Parse("2020-02-12"), EndDate =DateTime.Parse("2021-02-11"), Credits = 14  },
                new Project{ ProjectId = 13, StartDate= DateTime.Parse("2020-01-13"), EndDate =DateTime.Parse("2021-09-01"), Credits = 6  },
                new Project{ ProjectId = 14, StartDate= DateTime.Parse("2020-02-11"), EndDate =DateTime.Parse("2020-04-11"), Credits = 2  },
                new Project{ ProjectId = 15, StartDate= DateTime.Parse("2019-01-12"), EndDate =DateTime.Parse("2020-09-01"), Credits = 1  }
            };
            projects.ForEach(p => context.Projects.Add(p));
            context.SaveChanges();

            var userprojects = new List<UserProject> {
                new UserProject { UserId = 1, ProjectId = 1, AssignedDate =DateTime.Parse("2019-01-12") , IsActive =true },
                new UserProject { UserId = 1, ProjectId = 2, AssignedDate =DateTime.Parse("2020-10-02") , IsActive = false},
                new UserProject { UserId = 1, ProjectId = 3, AssignedDate =DateTime.Parse("2019-03-04") , IsActive =true },
                new UserProject { UserId = 1, ProjectId = 4, AssignedDate =DateTime.Parse("2019-01-12") , IsActive = true },
                new UserProject { UserId = 1, ProjectId = 5, AssignedDate =DateTime.Parse("2020-01-12") , IsActive =false },
                new UserProject { UserId = 2, ProjectId = 6, AssignedDate =DateTime.Parse("2019-10-12") , IsActive =true },
                new UserProject { UserId = 2, ProjectId = 7, AssignedDate =DateTime.Parse("2019-11-11") , IsActive =false },
                new UserProject { UserId = 2, ProjectId = 8, AssignedDate =DateTime.Parse("2019-11-30") , IsActive =false },
                new UserProject { UserId = 2, ProjectId = 9, AssignedDate =DateTime.Parse("2019-04-01") , IsActive =true },
                new UserProject { UserId = 2, ProjectId = 10, AssignedDate =DateTime.Parse("2019-07-11") , IsActive =true },
                new UserProject { UserId = 3, ProjectId = 11, AssignedDate =DateTime.Parse("2019-11-12") , IsActive = true},
                new UserProject { UserId = 3, ProjectId = 12, AssignedDate =DateTime.Parse("2019-01-12") , IsActive =false },
                new UserProject { UserId = 3, ProjectId = 13, AssignedDate =DateTime.Parse("2020-01-12") , IsActive =false },
                new UserProject { UserId = 3, ProjectId = 14, AssignedDate =DateTime.Parse("2012-01-13") , IsActive =true },
                new UserProject { UserId = 3, ProjectId = 15, AssignedDate =DateTime.Parse("2019-11-12") , IsActive =true }
            };
            userprojects.ForEach(up => context.UserProjects.Add(up));
            context.SaveChanges();
        }
    }
}