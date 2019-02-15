using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lygwys.BookList.Migrations
{
    public partial class Add_entity_booklistAndBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookListAndBooks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CloudBookListId = table.Column<long>(nullable: false),
                    BookId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookListAndBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookListAndBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookListAndBooks_CloudBookLists_CloudBookListId",
                        column: x => x.CloudBookListId,
                        principalTable: "CloudBookLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookListAndBooks_BookId",
                table: "BookListAndBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookListAndBooks_CloudBookListId",
                table: "BookListAndBooks",
                column: "CloudBookListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookListAndBooks");
        }
    }
}
