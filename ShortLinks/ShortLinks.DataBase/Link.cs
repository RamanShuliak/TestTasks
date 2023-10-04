using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinks.DataBase
{
    public class Link
    {
        public Guid Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int NumberOfTransitions { get; set; }
    }
}
