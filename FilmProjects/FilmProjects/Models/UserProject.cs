/* Developer:
 * James Camacho
 * 
 * File Name:
 * FilmProjectJoinedModel.cs
 * 
 * 
 * Main Functionality:
 * This Model File maintains data the userproject table in the database. 
 *
 * Version: 1.0
 * 
 * Last Edited : 11/9/19
 */

namespace FilmProjects.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class UserProject
    {
        public int UserProjectId { get; set; }
        public bool IsActive { get; set; }
        public DateTime AssignedDate { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
