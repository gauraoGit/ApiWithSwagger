using System;

namespace Library.API.Models
{
    /// <summary>
    /// Firstname, lastname and Idof an author
    /// </summary>
    public class Author
    {        
        /// <summary>
        /// The Id of the author
        /// </summary>
        public Guid Id { get; set; } 
     
        /// <summary>
        /// Firstname of an author
        /// </summary>
        public string FirstName { get; set; }
      
        /// <summary>
        /// The last name of an author
        /// </summary>
        public string LastName { get; set; }
    }
}
