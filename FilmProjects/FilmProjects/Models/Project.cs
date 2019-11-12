/* Developer:
 * James Camacho
 * 
 * File Name:
 * Project.cs
 * 
 * 
 * Main Functionality:
 * This Model File maintains data from the project table in the database. 
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

    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.UserProjects = new HashSet<UserProject>();
        }
    
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProject> UserProjects { get; set; }

    }
}
