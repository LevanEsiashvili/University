using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentSubjectExam_ExamId",
                schema: "core",
                table: "StudentSubjectExam");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacultyId",
                schema: "core",
                table: "Subject",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentSubjectId",
                schema: "core",
                table: "StudentSubjectExam",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "core",
                table: "StudentSubjectExam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "FacultyId",
                schema: "core",
                table: "Student",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectExam_ExamId",
                schema: "core",
                table: "StudentSubjectExam",
                column: "ExamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectExam_StudentSubjectId",
                schema: "core",
                table: "StudentSubjectExam",
                column: "StudentSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjectExam_StudentSubject_StudentSubjectId",
                schema: "core",
                table: "StudentSubjectExam",
                column: "StudentSubjectId",
                principalSchema: "core",
                principalTable: "StudentSubject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjectExam_StudentSubject_StudentSubjectId",
                schema: "core",
                table: "StudentSubjectExam");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjectExam_ExamId",
                schema: "core",
                table: "StudentSubjectExam");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjectExam_StudentSubjectId",
                schema: "core",
                table: "StudentSubjectExam");

            migrationBuilder.DropColumn(
                name: "StudentSubjectId",
                schema: "core",
                table: "StudentSubjectExam");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "core",
                table: "StudentSubjectExam");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacultyId",
                schema: "core",
                table: "Subject",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacultyId",
                schema: "core",
                table: "Student",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectExam_ExamId",
                schema: "core",
                table: "StudentSubjectExam",
                column: "ExamId");
        }
    }
}
