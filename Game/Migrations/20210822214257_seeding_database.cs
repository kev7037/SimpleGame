using Microsoft.EntityFrameworkCore.Migrations;

namespace Game.Migrations
{
    public partial class seeding_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Title" },
                values: new object[,]
                {
                    { 1, "Japanese", "Japan" },
                    { 2, "Chinese", "China" },
                    { 3, "Korean", "Korea" },
                    { 4, "Thai", "Thailand" }
                });

            migrationBuilder.InsertData(
                table: "GameData",
                columns: new[] { "Id", "Answer", "ImgUrl" },
                values: new object[,]
                {
                    { 11, 4, "/Images/4_2.jpg" },
                    { 10, 4, "/Images/4_1.jpg" },
                    { 9, 3, "/Images/3_3.jpg" },
                    { 8, 3, "/Images/3_2.jpg" },
                    { 7, 3, "/Images/3_1.jpg" },
                    { 5, 2, "/Images/2_2.jpg" },
                    { 12, 4, "/Images/4_3.jpg" },
                    { 4, 2, "/Images/2_1.jpg" },
                    { 3, 1, "/Images/1_3.jpg" },
                    { 2, 1, "/Images/1_2.jpg" },
                    { 1, 1, "/Images/1_1.jpg" },
                    { 6, 2, "/Images/2_3.jpg" },
                    { 13, 4, "/Images/4_4.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GameData",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
