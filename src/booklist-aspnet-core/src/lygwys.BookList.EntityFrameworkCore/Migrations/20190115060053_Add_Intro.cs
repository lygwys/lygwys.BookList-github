using Microsoft.EntityFrameworkCore.Migrations;

namespace lygwys.BookList.Migrations
{
    public partial class Add_Intro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Intro",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Intro",
                table: "Books");
        }
    }
}
