using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject.Models
{
    //Child to the IdentityUser
    public class Blog
    {
        //Id of the blog entery
        public int Id { get; set; }
        //author of the entry
        public string BlogUserId { get; set; }
        //Title/Description entry
        [Required]
        //passing an error message with 0 = name of variable, 2 = minimumLength value, 1 = 100
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        //passing an error message with 0 = name of variable, 2 = minimumLength value, 1 = 100
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Description { get; set; }

        //Date blog was created
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        //Date blog was updated/edited - can be nullable
        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        //byte array for storing image data
        [Display(Name = "Blog Image")]
        public byte[] ImageData { get; set; }
        // storing type of file so we can convert back to an image
        [Display(Name = "Image Type")]
        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        //Navigation property - Child to IdentityUser
        public virtual BlogUser BlogUser { get; set; }
        //Parent to a collection of Posts
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    }
}
