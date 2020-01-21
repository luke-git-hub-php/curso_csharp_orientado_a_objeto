using System;

namespace NaniWeb.Data.Entities
{
    public class Link
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public bool Active { get; set; }
    }
}