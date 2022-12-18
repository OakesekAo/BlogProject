﻿using BlogProject.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models
{
    public class Comment
    {

        /// This is the comment model section. All the needed data properties for the section that handles the comments and tied to the blog topic
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string ModeratorId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more than {1}", MinimumLength = 2)]
        [Display(Name = "Comment")]
        public string Body { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Moderated { get; set; }
        public DateTime? Deleted { get; set; }



        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more than {1}", MinimumLength = 2)]
        [Display(Name = "Moderated Comment")]
        public string ModerateBody { get; set; }
        //For recording the reason for moderating
        public ModerationType ModerationType { get; set; }

        //Navigation properties - Comment is Child to Post model
        public virtual Post Post { get; set; }
        public virtual BlogUser Author { get; set; }
        public virtual BlogUser Moderator { get; set; }

    }
}
