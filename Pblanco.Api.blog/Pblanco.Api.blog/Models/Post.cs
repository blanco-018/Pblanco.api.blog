using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pblanco.Api.blog.Controllers
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public string ShortBody
        {
            get
            {
                if (Body.Length > 100)
                {
                    return Body.Substring(0, 100) + "...";
                }
                else
                {
                    return Body;
                }
            }
        }
    }
}
    
