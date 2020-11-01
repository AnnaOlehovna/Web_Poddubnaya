using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.DAL.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CertificateGroups",
                columns: table => new
                {
                    CertificateGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateGroups", x => x.CertificateGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    CertificateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    CertificateGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateId);
                    table.ForeignKey(
                        name: "FK_Certificates_CertificateGroups_CertificateGroupId",
                        column: x => x.CertificateGroupId,
                        principalTable: "CertificateGroups",
                        principalColumn: "CertificateGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CertificateGroupId",
                table: "Certificates",
                column: "CertificateGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "CertificateGroups");
        }
    }
}
