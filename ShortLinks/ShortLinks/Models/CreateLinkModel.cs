using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ShortLinks.Models
{
    public class CreateLinkModel
    {
        [Required]
        [Remote("CheckLongUrl", "Link",
            HttpMethod = WebRequestMethods.Http.Post,
            ErrorMessage = "This link is already exist.")]
        public string LongUrl { get; set; }

        [Required]
        [Remote("CheckShortUrl", "Link",
            HttpMethod = WebRequestMethods.Http.Post,
            ErrorMessage = "This short URL is already use.")]
        public string ShortUrl { get; set; }

    }
}
