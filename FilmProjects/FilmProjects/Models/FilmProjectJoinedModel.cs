/* Developer:
 * James Camacho
 * 
 * File Name:
 * FilmProjectJoinedModel.cs
 * 
 * 
 * Main Functionality:
 * This Model File maintains data from every table in the database. 
 *
 * Version: 1.0
 * 
 * Last Edited : 11/9/19
 */




using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmProjects.Models
{

    public class FilmProjectJoinedModel
    {
        public int projectId { get; set; }
        public DateTime startDate { get; set; }
        public double timetoStart { get; set; }
        public DateTime endate { get; set; }
        public int credits { get; set; }
        public bool status { get; set; }
        public DateTime assignedDate { get; set; }
    }
}