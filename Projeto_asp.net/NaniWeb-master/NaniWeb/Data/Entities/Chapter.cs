using System;
using System.Collections.Generic;

namespace NaniWeb.Data.Entities
{
    public abstract class Chapter
    {
        public Guid Id { get; set; }
        public decimal Volume { get; set; }
        public decimal Number { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Visible { get; set; }
        public Guid SeriesId { get; set; }

        public Series Series { get; set; }
        public IEnumerable<Page> Pages { get; set; }
    }
}