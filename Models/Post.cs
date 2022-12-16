﻿using Microsoft.AspNetCore.Http;
using System;
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
        public int BlogId { get; set; }
        //FK for the author
        public string AuthorId { get; set; }

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
        public bool IsReady { get; set; }
        //Slug value 
        public string Slug { get; set; }

        //Ability to store image data
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        //property to be excluded from the DB
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
