using BlogProject.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject.Models
{
    public class Post
    {
        //primary key
        public int Id { get; set; }
        //FK for the blog Id
        [Display(Name ="Blog Name")]
        public int BlogId { get; set; }
        //FK for the author
        public string BlogUserId { get; set; }

        //Title of blog
        [Required]
        [StringLength(75, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long", MinimumLength = 2)]
        public string Title { get; set; }


        //Blurb for summary of the blog post
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long", MinimumLength = 2)]
        public string Abstract { get; set; }

        //Contents of blog post
        [Required]
        public string Content { get; set; }

        //Created/updated values
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        //flag used to determine if its posted or hidden to public view
        public ReadyStatus ReadyStatus { get; set; }
        //Slug value 
        public string Slug { get; set; }

        //Ability to store image data
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        //property to be excluded from the DB
        [NotMapped]
        public IFormFile Image { get; set; }

        //Navigation property Child to Blog model
        public virtual Blog Blog { get; set; }
        public virtual BlogUser BlogUser { get; set; }
        //Parent to Tag and Comment class model
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
