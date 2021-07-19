using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction___.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usersLots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialPrice = table.Column<int>(type: "int", nullable: false),
                    Finalprice = table.Column<int>(type: "int", nullable: false),
                    UsetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersLots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usersLots_usersModels_UserId",
                        column: x => x.UserId,
                        principalTable: "usersModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usersLots_UserId",
                table: "usersLots",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usersLots");
        }
    }
}
