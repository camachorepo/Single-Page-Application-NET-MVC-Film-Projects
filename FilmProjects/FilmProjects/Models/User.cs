/* Developer:
 * James Camacho
 * 
 * File Name:
 * FilmProjectJoinedModel.cs
 * 
 * 
 * Main Functionality:
 * This Model File maintains data from the user table in the database. 
 *
 * Version: 1.0
 * 
 * Last Edited : 11/9/19
 */

namespace FilmProjects.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.UserProjects = new HashSet<UserProject>();
        }
    
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
