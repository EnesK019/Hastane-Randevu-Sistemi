using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hastane_Randevu_Sistemi.Migrations
{
    /// <inheritdoc />
    public partial class calismagünleriyapıldı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalismaGunleri",
                columns: table => new
                {
                    CalismaGunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gunler = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Saatler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalismaGunleri", x => x.CalismaGunID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalismaGunleri");
        }
    }
}
