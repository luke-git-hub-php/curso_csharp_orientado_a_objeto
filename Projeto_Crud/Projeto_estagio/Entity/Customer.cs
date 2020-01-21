using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Customer
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Birth date is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    } 
    }
