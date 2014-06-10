using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class NoteViewModel
    {
        public int CustomerId { get; set; }

        [Required]
        public string Body { get; set; }
    }
}