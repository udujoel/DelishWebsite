using System.ComponentModel.DataAnnotations;

namespace DelishWebsite.Models
{
    public class Email
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}