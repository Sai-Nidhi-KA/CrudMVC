using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationmvc.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage ="Address is required.")]
        [DisplayName("Address")]
        public string Address { get; set; }

    }
}