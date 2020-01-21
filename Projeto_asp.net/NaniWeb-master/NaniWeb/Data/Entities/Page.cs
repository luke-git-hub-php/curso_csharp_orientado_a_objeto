using System;

namespace NaniWeb.Data.Entities
{
    public abstract class Page
    {
        public Guid Id { get; set; }
        public bool Animated { get; set; }
        public Guid ChapterId { get; set; }

        public Chapter Chapter { get; set; }
    }
}