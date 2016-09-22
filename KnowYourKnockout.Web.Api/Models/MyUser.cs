using System.ComponentModel.DataAnnotations;

namespace KnowYourKnockout.Web.Api.Models
{
    public class MyUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string AboutMe { get; set; }
    }
}
