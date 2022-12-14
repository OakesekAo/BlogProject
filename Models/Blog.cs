using Microsoft.AspNetCore.Http;
using System;

namespace BlogProject.Models
{
    public class Blog
    {
        //Id of the blog entery
        public int Id { get; set; }
        //author of the entry
        public string AuthorId { get; set; }
        //Title/Description entry
        public string Name { get; set; }
        public string Description { get; set; }
        //Date blog was created
        public DateTime Created { get; set; }
        //Date blog was updated/edited - can be nullable
        public DateTime? Updated { get; set; }

        //byte array for storing image data
        public byte[] ImageData { get; set; }
        // storing type of file so we can convert back to an image
        public string ContentType { get; set; }
        public IFormFile Image { get; set; }

    }
}
