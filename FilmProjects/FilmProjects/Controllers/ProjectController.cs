/* Developer:
 * James Camacho
 * 
 * File Name:
 * ProjectController.cs
 * 
 * 
 * Main Functionality:
 * Handle all controller functions of Single Page MVC Website FilmProjects
 *
 * Version: 1.0
 * 
 * Last Edited : 11/9/19
 */



using FilmProjects.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace FilmProjects
{
    public class ProjectController : Controller
    {
        private FilmProjectContext db = new FilmProjectContext();

        /*
         * Function: 
         * Index 
         * 
         * Input: 
         * N/A
         * 
         * Output: 
         * Returns Blank data view to index.cshtml webpage.
         * 
         * Functionality:
         * Send intial data to Index webpage. 
         * 
         */
        public ActionResult Index()
        {
            return View();
        }

        /*
         * Function: 
         * all 
         * 
         * Input: 
         * Takes in Integer id which holds the primary key id of the user.
         * 
         * Output: 
         * Returns PartialView to Index.cshtml with all table data from database. 
         * 
         * Functionality:
         * Get all table data from user and return that back to the current webpage. 
         * 
         */
        [HttpGet]
        public JsonResult all(int id)
        {
            //Get  the database information stores in each table as a list
            List<User> userList = db.Users.ToList();
            List<Project> projectList = db.Projects.ToList();
            List<UserProject> userProjectList = db.UserProjects.ToList();

            var joinedTables = (from u in userList
                                join up in userProjectList on u.UserId equals up.UserId
                                join p in projectList on up.UserProjectId equals p.ProjectId
                                where u.UserId == id
                                select new FilmProjectJoinedModel
                                {
                                    projectId = p.ProjectId,
                                    startDate = p.StartDate,
                                    endate = p.EndDate,
                                    credits = p.Credits,
                                    status = up.IsActive, 
                                    assignedDate = up.AssignedDate
                                }
            ).ToList();
            foreach(FilmProjectJoinedModel fm in joinedTables)
            {
                fm.timetoStart = (fm.startDate - fm.assignedDate).TotalDays;
            }
                               
            return Json(joinedTables, JsonRequestBehavior.AllowGet);
        }

    }   
}
