using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class InitialDBCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocietyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocietyName = table.Column<string>(maxLength: 150, nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocietyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocietyMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(maxLength: 50, nullable: true),
                    MobileNo = table.Column<string>(maxLength: 11, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SocityInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocietyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocietyMembers_SocietyInfo_SocityInfoId",
                        column: x => x.SocityInfoId,
                        principalTable: "SocietyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocietyMembers_SocityInfoId",
                table: "SocietyMembers",
                column: "SocityInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocietyMembers");

            migrationBuilder.DropTable(
                name: "SocietyInfo");
        }
    }
}
