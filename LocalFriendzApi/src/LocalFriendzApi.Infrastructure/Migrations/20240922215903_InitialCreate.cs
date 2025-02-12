using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalFriendzApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CONTACT",
                columns: table => new
                {
                    id_contact = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    DDD = table.Column<string>(type: "VARCHAR", maxLength: 4, nullable: false),
                    email = table.Column<string>(type: "VARCHAR", maxLength: 40, nullable: false),
                    FeedbackMessage = table.Column<string>(type: "VARCHAR", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTACT", x => x.id_contact);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONTACT");
        }
    }
}
