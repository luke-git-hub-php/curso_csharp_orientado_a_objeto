using System;

namespace NaniWeb.Data.Entities
{
    public class Announcement
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Visible { get; set; }
    }
}