using Microsoft.EntityFrameworkCore.Migrations;

namespace lygwys.BookList.Migrations
{
    public partial class Add_tenant_for_someEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "CloudBookLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "BookTags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "BookListAndBooks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "BookAndBookTags",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CloudBookLists");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "BookTags");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "BookListAndBooks");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "BookAndBookTags");
        }
    }
}
