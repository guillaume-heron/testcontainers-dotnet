using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestContainers.Api.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Create_Articles_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blog");

            migrationBuilder.CreateTable(
                name: "articles",
                schema: "blog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    author = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    isDraft = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    releaseDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles",
                schema: "blog");
        }
    }
}
