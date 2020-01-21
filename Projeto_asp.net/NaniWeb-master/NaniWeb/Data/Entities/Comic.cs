namespace NaniWeb.Data.Entities
{
    public class Comic : Series
    {
        public bool LongStrip { get; set; }
        public ulong MangadexId { get; set; }
    }
}