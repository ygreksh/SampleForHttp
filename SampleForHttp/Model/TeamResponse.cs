using System.Collections;
using System.Collections.Generic;

namespace SampleForHttp.Model
{
    public class TeamResponse
    {
        public  IEnumerable<Team> Teams { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}