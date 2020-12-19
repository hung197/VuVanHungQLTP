using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace demoBackEndQlTp2.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "thanhPhos",
                columns: table => new
                {
                    MaTp = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenTp = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thanhPhos", x => x.MaTp);
                });

            migrationBuilder.CreateTable(
                name: "quanHuyens",
                columns: table => new
                {
                    MaQuanHuyen = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenQuanHuyen = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    MaTp = table.Column<int>(nullable: false),
                    ThanhPhoMaTp = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quanHuyens", x => x.MaQuanHuyen);
                    table.ForeignKey(
                        name: "FK_quanHuyens_thanhPhos_MaTp",
                        column: x => x.MaTp,
                        principalTable: "thanhPhos",
                        principalColumn: "MaTp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quanHuyens_thanhPhos_ThanhPhoMaTp",
                        column: x => x.ThanhPhoMaTp,
                        principalTable: "thanhPhos",
                        principalColumn: "MaTp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "xaPhuongs",
                columns: table => new
                {
                    MaXaPhuong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenXaPhuong = table.Column<string>(nullable: true),
                    MaQuanHuyen = table.Column<int>(nullable: false),
                    QuanHuyenMaQuanHuyen = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xaPhuongs", x => x.MaXaPhuong);
                    table.ForeignKey(
                        name: "FK_xaPhuongs_quanHuyens_MaQuanHuyen",
                        column: x => x.MaQuanHuyen,
                        principalTable: "quanHuyens",
                        principalColumn: "MaQuanHuyen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_xaPhuongs_quanHuyens_QuanHuyenMaQuanHuyen",
                        column: x => x.QuanHuyenMaQuanHuyen,
                        principalTable: "quanHuyens",
                        principalColumn: "MaQuanHuyen",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quanHuyens_MaTp",
                table: "quanHuyens",
                column: "MaTp");

            migrationBuilder.CreateIndex(
                name: "IX_quanHuyens_ThanhPhoMaTp",
                table: "quanHuyens",
                column: "ThanhPhoMaTp");

            migrationBuilder.CreateIndex(
                name: "IX_xaPhuongs_MaQuanHuyen",
                table: "xaPhuongs",
                column: "MaQuanHuyen");

            migrationBuilder.CreateIndex(
                name: "IX_xaPhuongs_QuanHuyenMaQuanHuyen",
                table: "xaPhuongs",
                column: "QuanHuyenMaQuanHuyen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "xaPhuongs");

            migrationBuilder.DropTable(
                name: "quanHuyens");

            migrationBuilder.DropTable(
                name: "thanhPhos");
        }
    }
}
