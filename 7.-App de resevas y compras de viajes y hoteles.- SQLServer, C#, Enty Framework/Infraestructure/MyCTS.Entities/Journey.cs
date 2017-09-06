using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCTS.Entities
{
    public class Journey
    {
        public List<Segment> Segments { get; set; }

        public Journey()
        {
            Segments = new List<Segment>();
        }

        public Journey(List<Segment> segments)
        {
            Segments = segments;
        }
    }
}
