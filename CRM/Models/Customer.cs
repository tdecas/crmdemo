using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Customer
    {
        [Required]
        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }

        [Required]
        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [DisplayName("State")]
        public string State { get; set; }

        public List<Note> Notes { get; set; } 
    }
}