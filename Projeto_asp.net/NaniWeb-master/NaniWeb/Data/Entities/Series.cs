using System;
using System.Collections.Generic;

namespace NaniWeb.Data.Entities
{
    public abstract class Series
    {
        public enum Statuses
        {
            Ongoing,
            Completed,
            Dropped
        }

        public Guid Id { get; set; }
        public string UrlSlug { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Author { get; set; }
        public string Artist { get; set; }
        public string[] Tags { get; set; }
        public string Synopsis { get; set; }
        public string PreviousChaptersUrl { get; set; }
        public Statuses Status { get; set; }
        public bool NSFW { get; set; }
        public bool Visible { get; set; }
        public ulong DiscordRoleId { get; set; }
        public string DiscordReactionName { get; set; }

        public IEnumerable<Chapter> Chapters { get; set; }
    }
}