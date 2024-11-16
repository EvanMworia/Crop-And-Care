using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    FarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarmLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProduceExpected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PesticideUsage = table.Column<bool>(type: "bit", nullable: true),
                    CertifyAsOrganicFarmer = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.FarmId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farmers");
        }
    }
}
