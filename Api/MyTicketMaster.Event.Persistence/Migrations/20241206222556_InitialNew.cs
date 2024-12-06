using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyTicketMaster.Event.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("64379420-5da1-425e-aeb2-da3d92217528"), "Beauty and the Beast" },
                    { new Guid("7888e967-af2a-4b81-b971-034c003835fa"), "MJ the Musical" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("23d2da3b-c620-498e-b5cf-1a20a383cff7"), "Optus Stadium" },
                    { new Guid("5f7c5002-ff20-4351-8d5e-4e7eb91a1bea"), "Fremantle Prison" },
                    { new Guid("7225dcb0-530f-4054-9188-6a308d981499"), "Burswood Park" },
                    { new Guid("c04e75ff-bbe5-4221-9651-d25ea06f1375"), "Mt Duneed Estate" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_Name",
                table: "Events",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
