using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hastane_Randevu_Sistemi.Migrations
{
    public partial class randevu_deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RandevuTarih",
                table: "Randevu",
                newName: "RandevuGun");

            migrationBuilder.CreateTable(
                name: "Saat",
                columns: table => new
                {
                    SaatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RandevuId = table.Column<int>(type: "int", nullable: false),
                    RandevuSaat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saat", x => x.SaatID);
                    table.ForeignKey(
                        name: "FK_Saat_Randevu_RandevuId",
                        column: x => x.RandevuId,
                        principalTable: "Randevu",
                        principalColumn: "RandevuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Saat_RandevuId",
                table: "Saat",
                column: "RandevuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saat");

            migrationBuilder.RenameColumn(
                name: "RandevuGun",
                table: "Randevu",
                newName: "RandevuTarih");
        }
    }
}
