using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class UserProfile
    {
        [Required]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public int Id { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
    }
}