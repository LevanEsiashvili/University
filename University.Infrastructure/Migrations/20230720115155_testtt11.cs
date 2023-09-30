using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testtt11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LecturerId",
                schema: "core",
                table: "Exam",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Exam_LecturerId",
                schema: "core",
                table: "Exam",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Lecturer_LecturerId",
                schema: "core",
                table: "Exam",
                column: "LecturerId",
                principalSchema: "core",
                principalTable: "Lecturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Lecturer_LecturerId",
                schema: "core",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_LecturerId",
                schema: "core",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                schema: "core",
                table: "Exam");
        }
    }
}
