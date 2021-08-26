using System;

namespace SampleForHttp.Model
{
    public class Team
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int foundationYear { get; set; } 
        public string division { get; set; }
        public string conference { get; set; }
        public string imageUrl { get; set; }
        
    }
}