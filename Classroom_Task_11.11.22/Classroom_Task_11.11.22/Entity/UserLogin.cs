using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Classroom_Task_11._11._22.Entity
{
    public class UserLogin
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Phone number")]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
       
    }
}
