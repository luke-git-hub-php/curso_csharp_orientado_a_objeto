using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NaniWeb.Data.Entities;
using Npgsql;
using Npgsql.NameTranslation;

namespace NaniWeb.Data
{
    public class NaniDb : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DbSet<Announcement> Announcements;
        public DbSet<Chapter> Chapters;
        public DbSet<ComicChapter> ComicChapters;
        public DbSet<ComicPage> ComicPages;
        public DbSet<Comic> Comics;
        public DbSet<Link> Links;
        public DbSet<NovelChapter> NovelChapters;
        public DbSet<NovelPage> NovelPages;
        public DbSet<Novel> Novels;
        public DbSet<Page> Pages;
        public DbSet<Resource> Resources;
        public DbSet<Series> Series;

        static NaniDb()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Series.Statuses>(null, new NpgsqlNullNameTranslator());
        }

        public NaniDb(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresEnum<Series.Statuses>(null, null, new NpgsqlNullNameTranslator());
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser<Guid>>().ToTable("Users");
            builder.Entity<IdentityRole<Guid>>().ToTable("Roles");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

            builder.Entity<Series>(typeBuilder =>
            {
                typeBuilder.Property(series => series.UrlSlug).IsRequired();
                typeBuilder.HasIndex(series => series.UrlSlug).IsUnique();
                typeBuilder.Property(series => series.Name).IsRequired();
                typeBuilder.HasIndex(series => series.Name).IsUnique();
                typeBuilder.Property(series => series.OriginalName).IsRequired();
                typeBuilder.HasIndex(series => series.OriginalName).IsUnique();
                typeBuilder.Property(series => series.Author).IsRequired();
                typeBuilder.Property(series => series.Artist).IsRequired();
                typeBuilder.Property(series => series.Tags).IsRequired();
                typeBuilder.Property(series => series.Synopsis).IsRequired();
                typeBuilder.Property(series => series.Status).IsRequired();
                typeBuilder.Property(series => series.NSFW).IsRequired();
                typeBuilder.Property(series => series.Visible).IsRequired();
                typeBuilder.Property(series => series.DiscordRoleId).IsRequired();
                typeBuilder.HasIndex(series => series.DiscordRoleId).IsUnique();
                typeBuilder.Property(series => series.DiscordReactionName).IsRequired();
                typeBuilder.HasIndex(series => series.DiscordReactionName).IsUnique();
                typeBuilder.HasMany(comic => comic.Chapters).WithOne(chapter => chapter.Series).HasForeignKey(chapter => chapter.SeriesId);

                typeBuilder.HasDiscriminator<string>("SeriesType")
                    .HasValue<Comic>(typeof(Comic).Name)
                    .HasValue<Novel>(typeof(Novel).Name);
            });

            builder.Entity<Chapter>(typeBuilder =>
            {
                typeBuilder.Property(chapter => chapter.Number).IsRequired();
                typeBuilder.Property(chapter => chapter.Date).IsRequired();
                typeBuilder.Property(chapter => chapter.Visible).IsRequired();
                typeBuilder.Property(chapter => chapter.SeriesId).IsRequired();
                typeBuilder.HasIndex(chapter => new {chapter.Number, chapter.SeriesId});
                typeBuilder.HasMany(chapter => chapter.Pages).WithOne(page => page.Chapter).HasForeignKey(chapter => chapter.ChapterId);

                typeBuilder.HasDiscriminator<string>("ChapterType")
                    .HasValue<ComicChapter>(typeof(ComicChapter).Name)
                    .HasValue<NovelChapter>(typeof(NovelChapter).Name);
            });

            builder.Entity<Page>(typeBuilder =>
            {
                typeBuilder.Property(chapter => chapter.Animated).IsRequired();
                typeBuilder.Property(chapter => chapter.ChapterId).IsRequired();

                typeBuilder.HasDiscriminator<string>("PageType")
                    .HasValue<ComicPage>(typeof(ComicPage).Name)
                    .HasValue<NovelPage>(typeof(NovelPage).Name);
            });

            builder.Entity<Comic>(typeBuilder =>
            {
                typeBuilder.Property(comic => comic.LongStrip).IsRequired();
                typeBuilder.Property(comic => comic.MangadexId).IsRequired();
            });

            builder.Entity<ComicChapter>(typeBuilder => typeBuilder.Property(chapter => chapter.MangadexId).IsRequired());

            builder.Entity<ComicPage>(typeBuilder =>
            {
                typeBuilder.Property(page => page.Number).IsRequired();
                typeBuilder.HasIndex(page => new {page.Number, page.ChapterId});
            });

            builder.Entity<Novel>();

            builder.Entity<NovelChapter>(typeBuilder => typeBuilder.Property(chapter => chapter.Content).IsRequired());

            builder.Entity<NovelPage>(typeBuilder =>
            {
                typeBuilder.Property(page => page.Name).IsRequired();
                typeBuilder.HasIndex(page => page.Name).IsUnique();
            });

            builder.Entity<Announcement>(typeBuilder =>
            {
                typeBuilder.Property(announcement => announcement.Title).IsRequired();
                typeBuilder.Property(announcement => announcement.Content).IsRequired();
                typeBuilder.Property(announcement => announcement.Date).IsRequired();
                typeBuilder.Property(announcement => announcement.Visible).IsRequired();
            });

            builder.Entity<Resource>(typeBuilder => typeBuilder.Property(resource => resource.FileName).IsRequired());

            builder.Entity<Link>(typeBuilder =>
            {
                typeBuilder.Property(link => link.Name).IsRequired();
                typeBuilder.HasIndex(link => link.Name).IsUnique();
                typeBuilder.Property(link => link.Destination).IsRequired();
                typeBuilder.Property(link => link.Active).IsRequired();
            });
        }
    }
}