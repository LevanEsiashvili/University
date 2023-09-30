using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAdminSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "core",
                table: "User",
                columns: new[] { "Id", "BirtsDate", "CreatedDate", "Email", "FirstName", "IsDeleted", "LastName", "LecturerId", "PasswordHash", "PasswordSalt", "PhoneNumber", "PrivateNumber", "Role", "StudentId" },
                values: new object[] { new Guid("692e35ad-4672-4632-bde0-607abb8fa0b8"), new DateTime(2023, 7, 22, 13, 42, 49, 315, DateTimeKind.Local).AddTicks(4224), new DateTime(2023, 7, 22, 13, 42, 49, 315, DateTimeKind.Local).AddTicks(4210), "1", "admin", false, "admin", null, new byte[] { 29, 75, 139, 229, 45, 15, 199, 111, 93, 170, 17, 198, 163, 161, 161, 143, 196, 82, 240, 3, 212, 137, 120, 167, 182, 231, 60, 224, 89, 244, 176, 232, 71, 32, 177, 138, 57, 51, 128, 37, 11, 106, 1, 69, 6, 174, 253, 62, 22, 35, 1, 148, 10, 155, 70, 48, 26, 15, 92, 53, 113, 224, 99, 126 }, new byte[] { 43, 130, 227, 178, 247, 137, 23, 234, 229, 161, 31, 15, 47, 128, 38, 171, 153, 195, 151, 221, 17, 81, 72, 91, 15, 244, 188, 50, 215, 61, 15, 99, 137, 145, 102, 72, 142, 21, 208, 159, 79, 221, 245, 171, 30, 127, 2, 231, 30, 22, 120, 35, 220, 149, 241, 202, 224, 18, 160, 67, 2, 216, 99, 36, 109, 72, 169, 156, 137, 34, 94, 242, 212, 242, 167, 224, 218, 77, 102, 200, 87, 140, 3, 151, 31, 112, 65, 244, 126, 11, 61, 1, 85, 201, 252, 118, 0, 101, 181, 22, 24, 123, 253, 36, 224, 210, 3, 20, 3, 177, 133, 131, 11, 71, 159, 228, 244, 40, 27, 248, 7, 127, 48, 244, 175, 176, 102, 39 }, "admin", "admin", 0, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("692e35ad-4672-4632-bde0-607abb8fa0b8"));
        }
    }
}
