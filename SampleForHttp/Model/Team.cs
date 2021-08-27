﻿using System;

namespace SampleForHttp.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FoundationYear { get; set; } 
        public string Division { get; set; }
        public string Conference { get; set; }
        public string ImageUrl { get; set; }
        
    }
}