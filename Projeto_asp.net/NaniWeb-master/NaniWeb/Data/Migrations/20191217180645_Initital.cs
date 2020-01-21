using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NaniWeb.Data.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NaniWeb.Data.Migrations
{
    public partial class Initital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:Statuses", "Ongoing,Completed,Dropped");

            migrationBuilder.CreateTable(
                "Announcement",
                table => new
                {
                    Id = table.Column<Guid>(),
                    Title = table.Column<string>(),
                    Content = table.Column<string>(),
                    Date = table.Column<DateTime>(),
                    Visible = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_Announcement", x => x.Id); });

            migrationBuilder.CreateTable(
                "Link",
                table => new
                {
                    Id = table.Column<Guid>(),
                    Name = table.Column<string>(),
                    Destination = table.Column<string>(),
                    Active = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_Link", x => x.Id); });

            migrationBuilder.CreateTable(
                "Resource",
                table => new
                {
                    Id = table.Column<Guid>(),
                    FileName = table.Column<string>()
                },
                constraints: table => { table.PrimaryKey("PK_Resource", x => x.Id); });

            migrationBuilder.CreateTable(
                "Roles",
                table => new
                {
                    Id = table.Column<Guid>(),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

            migrationBuilder.CreateTable(
                "Series",
                table => new
                {
                    Id = table.Column<Guid>(),
                    UrlSlug = table.Column<string>(),
                    Name = table.Column<string>(),
                    OriginalName = table.Column<string>(),
                    Author = table.Column<string>(),
                    Artist = table.Column<string>(),
                    Tags = table.Column<string[]>(),
                    Synopsis = table.Column<string>(),
                    PreviousChaptersUrl = table.Column<string>(nullable: true),
                    Status = table.Column<Series.Statuses>(),
                    NSFW = table.Column<bool>(),
                    Visible = table.Column<bool>(),
                    DiscordRoleId = table.Column<decimal>(),
                    DiscordReactionName = table.Column<string>(),
                    SeriesType = table.Column<string>(),
                    LongStrip = table.Column<bool>(nullable: true),
                    MangadexId = table.Column<decimal>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Series", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<Guid>(),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(),
                    TwoFactorEnabled = table.Column<bool>(),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(),
                    AccessFailedCount = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "RoleClaims",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);

                    table.ForeignKey(
                        "FK_RoleClaims_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Chapter",
                table => new
                {
                    Id = table.Column<Guid>(),
                    Volume = table.Column<decimal>(),
                    Number = table.Column<decimal>(),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(),
                    Visible = table.Column<bool>(),
                    SeriesId = table.Column<Guid>(),
                    ChapterType = table.Column<string>(),
                    MangadexId = table.Column<decimal>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);

                    table.ForeignKey(
                        "FK_Chapter_Series_SeriesId",
                        x => x.SeriesId,
                        "Series",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserClaims",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);

                    table.ForeignKey(
                        "FK_UserClaims_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>(),
                    ProviderKey = table.Column<string>(),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new {x.LoginProvider, x.ProviderKey});

                    table.ForeignKey(
                        "FK_UserLogins_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserRoles",
                table => new
                {
                    UserId = table.Column<Guid>(),
                    RoleId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new {x.UserId, x.RoleId});

                    table.ForeignKey(
                        "FK_UserRoles_Roles_RoleId",
                        x => x.RoleId,
                        "Roles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        "FK_UserRoles_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserTokens",
                table => new
                {
                    UserId = table.Column<Guid>(),
                    LoginProvider = table.Column<string>(),
                    Name = table.Column<string>(),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new {x.UserId, x.LoginProvider, x.Name});

                    table.ForeignKey(
                        "FK_UserTokens_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Page",
                table => new
                {
                    Id = table.Column<Guid>(),
                    Animated = table.Column<bool>(),
                    ChapterId = table.Column<Guid>(),
                    PageType = table.Column<string>(),
                    Number = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);

                    table.ForeignKey(
                        "FK_Page_Chapter_ChapterId",
                        x => x.ChapterId,
                        "Chapter",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Chapter_SeriesId",
                "Chapter",
                "SeriesId");

            migrationBuilder.CreateIndex(
                "IX_Chapter_Number_SeriesId",
                "Chapter",
                new[] {"Number", "SeriesId"});

            migrationBuilder.CreateIndex(
                "IX_Link_Name",
                "Link",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Page_Number_ChapterId",
                "Page",
                new[] {"Number", "ChapterId"});

            migrationBuilder.CreateIndex(
                "IX_Page_Name",
                "Page",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Page_ChapterId",
                "Page",
                "ChapterId");

            migrationBuilder.CreateIndex(
                "IX_RoleClaims_RoleId",
                "RoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "Roles",
                "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Series_DiscordReactionName",
                "Series",
                "DiscordReactionName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Series_DiscordRoleId",
                "Series",
                "DiscordRoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Series_Name",
                "Series",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Series_OriginalName",
                "Series",
                "OriginalName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Series_UrlSlug",
                "Series",
                "UrlSlug",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_UserClaims_UserId",
                "UserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserLogins_UserId",
                "UserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserRoles_RoleId",
                "UserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "Users",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "Users",
                "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Announcement");
            migrationBuilder.DropTable("Link");
            migrationBuilder.DropTable("Page");
            migrationBuilder.DropTable("Resource");
            migrationBuilder.DropTable("RoleClaims");
            migrationBuilder.DropTable("UserClaims");
            migrationBuilder.DropTable("UserLogins");
            migrationBuilder.DropTable("UserRoles");
            migrationBuilder.DropTable("UserTokens");
            migrationBuilder.DropTable("Chapter");
            migrationBuilder.DropTable("Roles");
            migrationBuilder.DropTable("Users");
            migrationBuilder.DropTable("Series");
        }
    }
}