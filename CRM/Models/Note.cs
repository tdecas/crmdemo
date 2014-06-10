using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Note
    {
        [Required]
        [DisplayName("Body")]
        public string Body { get; set; }

        public Customer Customer { get; set; }

        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        public int Id { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }
    }
}