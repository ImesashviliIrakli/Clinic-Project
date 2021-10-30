using Microsoft.EntityFrameworkCore.Migrations;

namespace Curatio.Migrations
{
    public partial class Form3Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormThree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(nullable: true),
                    DoctorName = table.Column<string>(nullable: true),
                    DoctorEmail = table.Column<string>(nullable: true),
                    DoctorPhone = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PrivateId = table.Column<string>(nullable: true),
                    Researches = table.Column<string>(nullable: true),
                    Transport = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormThree", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormThree");
        }
    }
}
