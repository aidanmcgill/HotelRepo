using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class adddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Name", "NumberOfDeluxRooms", "NumberOfDoubleRooms", "NumberOfSingleRooms" },
                values: new object[] { new Guid("727c5798-5771-43ca-9401-0ff3aed2d8c5"), "Glasgow Hotel", 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "HotelId", "RoomCapacity", "RoomType" },
                values: new object[,]
                {
                    { new Guid("6528d02b-23de-4eba-8321-26321614394d"), new Guid("727c5798-5771-43ca-9401-0ff3aed2d8c5"), 1, "Single" },
                    { new Guid("959d8519-e10f-4c83-81a4-b4849878d51c"), new Guid("727c5798-5771-43ca-9401-0ff3aed2d8c5"), 1, "Single" },
                    { new Guid("b30a4802-1e53-437c-9ec9-0e135769b0fa"), new Guid("727c5798-5771-43ca-9401-0ff3aed2d8c5"), 3, "Deluxe" },
                    { new Guid("bc4af3da-8e0b-49b1-9b00-8503ba54d4e1"), new Guid("727c5798-5771-43ca-9401-0ff3aed2d8c5"), 2, "Double" },
                    { new Guid("c2bc905b-b3ef-4c1f-a53d-68ec36c00840"), new Guid("727c5798-5771-43ca-9401-0ff3aed2d8c5"), 2, "Double" },
                    { new Guid("f8d4b0ad-157a-4b7c-83b9-625a0c7f5e4b"), new Guid("727c5798-5771-43ca-9401-0ff3aed2d8c5"), 3, "Deluxe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("727c5798-5771-43ca-9401-0ff3aed2d8c5"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6528d02b-23de-4eba-8321-26321614394d"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("959d8519-e10f-4c83-81a4-b4849878d51c"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b30a4802-1e53-437c-9ec9-0e135769b0fa"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("bc4af3da-8e0b-49b1-9b00-8503ba54d4e1"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c2bc905b-b3ef-4c1f-a53d-68ec36c00840"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("f8d4b0ad-157a-4b7c-83b9-625a0c7f5e4b"));
        }
    }
}
