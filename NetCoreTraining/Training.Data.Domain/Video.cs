using System;

namespace Training.Data.Domain
{
    public class Video : Entity<Guid>
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public string DirectedBy { get; set; }
        public string Genre { get; set; }
    }
}