using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication5.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    floor_No = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hotel_RoomId",
                table: "hotel",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_hotel_Room_RoomId",
                table: "hotel",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotel_Room_RoomId",
                table: "hotel");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_hotel_RoomId",
                table: "hotel");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "hotel");
        }
    }
}
