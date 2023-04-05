using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DU.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentHobbys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    H_Id = table.Column<int>(type: "int", nullable: false),
                    S_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHobbys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentHobbys_Hobbys_H_Id",
                        column: x => x.H_Id,
                        principalTable: "Hobbys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentHobbys_Students_S_Id",
                        column: x => x.S_Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentHobbys_H_Id",
                table: "StudentHobbys",
                column: "H_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHobbys_S_Id",
                table: "StudentHobbys",
                column: "S_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentHobbys");

            migrationBuilder.DropTable(
                name: "Hobbys");
        }
    }
}
