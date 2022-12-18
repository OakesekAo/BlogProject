using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models
{
    public class Tag
    {
        //Model handling the needed data for taging a blog with a topic of interest
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        public string Text { get; set; }

        //Navigation properties - Chold to Post
        public virtual Post Post { get; set; }
        public virtual IdentityUser Author { get; set; }

    }
}
