using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinks.Core
{
    public class LinkDto
    {
        public Guid Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int NumberOfTransitions { get; set; }
    }
}
