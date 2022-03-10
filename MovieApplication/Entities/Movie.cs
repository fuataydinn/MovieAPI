using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Time { get; set; }
        public string Comment { get; set; }
        public bool State { get; set; }



    }
}
