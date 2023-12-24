using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hastane_Randevu_Sistemi.Migrations
{
    public partial class randevu1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevu_AspNetUsers_KullaniciId1",
                table: "Randevu");

            migrationBuilder.DropIndex(
                name: "IX_Randevu_KullaniciId1",
                table: "Randevu");

            migrationBuilder.DropColumn(
                name: "KullaniciId1",
                table: "Randevu");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciId",
                table: "Randevu",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_KullaniciId",
                table: "Randevu",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevu_AspNetUsers_KullaniciId",
                table: "Randevu",
                column: "KullaniciId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevu_AspNetUsers_KullaniciId",
                table: "Randevu");

            migrationBuilder.DropIndex(
                name: "IX_Randevu_KullaniciId",
                table: "Randevu");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Randevu",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "KullaniciId1",
                table: "Randevu",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_KullaniciId1",
                table: "Randevu",
                column: "KullaniciId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevu_AspNetUsers_KullaniciId1",
                table: "Randevu",
                column: "KullaniciId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
