using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    // Represents a user entity in the application
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultValue(1)]
        public int Id { get; set; }
        [DefaultValue("Mark")]
        public string Name { get; set; }
        [Phone]
        [DefaultValue("333 333 333")]
        public string Phone { get; set; }        
        [EmailAddress]
        public string Email { get; set; }
    }
}