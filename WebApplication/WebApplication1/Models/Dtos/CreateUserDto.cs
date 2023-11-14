using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Models.Dtos
{
    // Data Transfer Object (DTO) used for creating a new user and updating existing one
    public class CreateUserDto
    {
        [DefaultValue("Mark")]
        public string Name { get; set; }
        [Phone]
        [DefaultValue("333 333 333")]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
