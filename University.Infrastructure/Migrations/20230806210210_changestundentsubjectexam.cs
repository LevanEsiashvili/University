using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changestundentsubjectexam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("692e35ad-4672-4632-bde0-607abb8fa0b8"));

            migrationBuilder.DropColumn(
                name: "MaximalResult",
                schema: "core",
                table: "StudentSubjectExam");

            migrationBuilder.DropColumn(
                name: "MinimalResult",
                schema: "core",
                table: "StudentSubjectExam");

            migrationBuilder.InsertData(
                schema: "core",
                table: "User",
                columns: new[] { "Id", "BirtsDate", "CreatedDate", "Email", "FirstName", "IsDeleted", "LastName", "LecturerId", "PasswordHash", "PasswordSalt", "PhoneNumber", "PrivateNumber", "Role", "StudentId" },
                values: new object[] { new Guid("6af7e55f-8910-4552-acf0-16a31a847a0e"), new DateTime(2023, 8, 7, 1, 2, 10, 378, DateTimeKind.Local).AddTicks(1136), new DateTime(2023, 8, 7, 1, 2, 10, 378, DateTimeKind.Local).AddTicks(1124), "1", "admin", false, "admin", null, new byte[] { 9, 0, 226, 245, 106, 42, 253, 70, 164, 16, 162, 20, 32, 178, 237, 22, 58, 43, 172, 242, 206, 17, 37, 166, 133, 177, 228, 210, 46, 196, 186, 196, 5, 56, 110, 236, 49, 230, 107, 59, 203, 75, 204, 159, 90, 84, 118, 47, 230, 115, 38, 247, 70, 96, 129, 85, 200, 77, 97, 92, 48, 192, 46, 49 }, new byte[] { 95, 149, 200, 60, 88, 247, 159, 12, 31, 8, 197, 98, 211, 71, 119, 181, 102, 236, 155, 64, 88, 225, 246, 129, 34, 29, 144, 194, 17, 156, 165, 84, 159, 144, 209, 59, 198, 69, 155, 134, 153, 212, 216, 206, 159, 29, 42, 93, 25, 192, 187, 146, 131, 36, 34, 10, 52, 38, 167, 184, 110, 16, 16, 40, 250, 215, 135, 183, 241, 40, 211, 215, 56, 114, 17, 40, 7, 172, 149, 21, 174, 229, 177, 83, 136, 183, 152, 97, 160, 149, 143, 79, 160, 192, 178, 169, 139, 198, 60, 56, 135, 71, 197, 153, 196, 188, 71, 134, 141, 118, 21, 49, 113, 243, 28, 197, 249, 55, 56, 63, 109, 130, 186, 132, 20, 241, 4, 49 }, "admin", "admin", 0, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "core",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6af7e55f-8910-4552-acf0-16a31a847a0e"));

            migrationBuilder.AddColumn<int>(
                name: "MaximalResult",
                schema: "core",
                table: "StudentSubjectExam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "MinimalResult",
                schema: "core",
                table: "StudentSubjectExam",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                schema: "core",
                table: "User",
                columns: new[] { "Id", "BirtsDate", "CreatedDate", "Email", "FirstName", "IsDeleted", "LastName", "LecturerId", "PasswordHash", "PasswordSalt", "PhoneNumber", "PrivateNumber", "Role", "StudentId" },
                values: new object[] { new Guid("692e35ad-4672-4632-bde0-607abb8fa0b8"), new DateTime(2023, 7, 22, 13, 42, 49, 315, DateTimeKind.Local).AddTicks(4224), new DateTime(2023, 7, 22, 13, 42, 49, 315, DateTimeKind.Local).AddTicks(4210), "1", "admin", false, "admin", null, new byte[] { 29, 75, 139, 229, 45, 15, 199, 111, 93, 170, 17, 198, 163, 161, 161, 143, 196, 82, 240, 3, 212, 137, 120, 167, 182, 231, 60, 224, 89, 244, 176, 232, 71, 32, 177, 138, 57, 51, 128, 37, 11, 106, 1, 69, 6, 174, 253, 62, 22, 35, 1, 148, 10, 155, 70, 48, 26, 15, 92, 53, 113, 224, 99, 126 }, new byte[] { 43, 130, 227, 178, 247, 137, 23, 234, 229, 161, 31, 15, 47, 128, 38, 171, 153, 195, 151, 221, 17, 81, 72, 91, 15, 244, 188, 50, 215, 61, 15, 99, 137, 145, 102, 72, 142, 21, 208, 159, 79, 221, 245, 171, 30, 127, 2, 231, 30, 22, 120, 35, 220, 149, 241, 202, 224, 18, 160, 67, 2, 216, 99, 36, 109, 72, 169, 156, 137, 34, 94, 242, 212, 242, 167, 224, 218, 77, 102, 200, 87, 140, 3, 151, 31, 112, 65, 244, 126, 11, 61, 1, 85, 201, 252, 118, 0, 101, 181, 22, 24, 123, 253, 36, 224, 210, 3, 20, 3, 177, 133, 131, 11, 71, 159, 228, 244, 40, 27, 248, 7, 127, 48, 244, 175, 176, 102, 39 }, "admin", "admin", 0, null });
        }
    }
}
