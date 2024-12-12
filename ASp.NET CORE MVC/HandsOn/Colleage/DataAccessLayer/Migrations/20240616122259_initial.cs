using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DepId);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    StuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StuName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StuCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StuDepID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.StuId);
                    table.ForeignKey(
                        name: "FK_students_departments_StuDepID",
                        column: x => x.StuDepID,
                        principalTable: "departments",
                        principalColumn: "DepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "DepId", "DepName" },
                values: new object[,]
                {
                    { 1, "SocialWork" },
                    { 2, "Information Technology" },
                    { 3, "Computer Science" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "StuId", "StuCity", "StuDepID", "StuName" },
                values: new object[,]
                {
                    { 1, "Liverpool", 1, "Lisa" },
                    { 2, "Widnes", 2, "Siva" },
                    { 3, "Birmingham", 3, "Nagu" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_StuDepID",
                table: "students",
                column: "StuDepID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
