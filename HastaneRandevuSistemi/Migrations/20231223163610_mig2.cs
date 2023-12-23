using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemi.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "UserSurname",
                table: "AspNetUsers",
                newName: "TcNo");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAd",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciSoyad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_DoktorId",
                table: "Randevu",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinik_HastaneId",
                table: "Poliklinik",
                column: "HastaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktor_PoliklinikId",
                table: "Doktor",
                column: "PoliklinikId");

            migrationBuilder.CreateIndex(
                name: "IX_CalismaGunu_DoktorId",
                table: "CalismaGunu",
                column: "DoktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalismaGunu_Doktor_DoktorId",
                table: "CalismaGunu",
                column: "DoktorId",
                principalTable: "Doktor",
                principalColumn: "DoktorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doktor_Poliklinik_PoliklinikId",
                table: "Doktor",
                column: "PoliklinikId",
                principalTable: "Poliklinik",
                principalColumn: "PoliklinikID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Poliklinik_Hastane_HastaneId",
                table: "Poliklinik",
                column: "HastaneId",
                principalTable: "Hastane",
                principalColumn: "HastaneID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevu_Doktor_DoktorId",
                table: "Randevu",
                column: "DoktorId",
                principalTable: "Doktor",
                principalColumn: "DoktorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalismaGunu_Doktor_DoktorId",
                table: "CalismaGunu");

            migrationBuilder.DropForeignKey(
                name: "FK_Doktor_Poliklinik_PoliklinikId",
                table: "Doktor");

            migrationBuilder.DropForeignKey(
                name: "FK_Poliklinik_Hastane_HastaneId",
                table: "Poliklinik");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevu_Doktor_DoktorId",
                table: "Randevu");

            migrationBuilder.DropIndex(
                name: "IX_Randevu_DoktorId",
                table: "Randevu");

            migrationBuilder.DropIndex(
                name: "IX_Poliklinik_HastaneId",
                table: "Poliklinik");

            migrationBuilder.DropIndex(
                name: "IX_Doktor_PoliklinikId",
                table: "Doktor");

            migrationBuilder.DropIndex(
                name: "IX_CalismaGunu_DoktorId",
                table: "CalismaGunu");

            migrationBuilder.DropColumn(
                name: "KullaniciAd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KullaniciSoyad",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TcNo",
                table: "AspNetUsers",
                newName: "UserSurname");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
