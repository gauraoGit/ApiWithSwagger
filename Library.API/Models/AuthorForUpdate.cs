using System.ComponentModel.DataAnnotations;

namespace Library.API.Models
{
    /// <summary>
    /// Updatable values Firstname and Lastname of an author
    /// </summary>
    public class AuthorForUpdate
    {
        /// <summary>
        /// Firstname of an Author
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        /// <summary>
        /// Lastname of an Author
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
    }
}
