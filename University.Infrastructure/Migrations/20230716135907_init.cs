using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.CreateTable(
                name: "Faculty",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualificationYare = table.Column<int>(type: "int", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraduatedSchool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacultyId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "core",
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Faculty_FacultyId1",
                        column: x => x.FacultyId1,
                        principalSchema: "core",
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "core",
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirtsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrivateNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LecturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalSchema: "core",
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "core",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MinimalResult = table.Column<double>(type: "float", nullable: false),
                    MaximalResult = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "core",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerSubject",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LecturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerSubject_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalSchema: "core",
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LecturerSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "core",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "core",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "core",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectProgram",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BookPages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectProgram_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "core",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjectExam",
                schema: "core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: false),
                    MinimalResult = table.Column<double>(type: "float", nullable: false),
                    MaximalResult = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjectExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubjectExam_Exam_ExamId",
                        column: x => x.ExamId,
                        principalSchema: "core",
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exam_SubjectId",
                schema: "core",
                table: "Exam",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerSubject_LecturerId",
                schema: "core",
                table: "LecturerSubject",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerSubject_SubjectId",
                schema: "core",
                table: "LecturerSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FacultyId",
                schema: "core",
                table: "Student",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FacultyId1",
                schema: "core",
                table: "Student",
                column: "FacultyId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudentId",
                schema: "core",
                table: "StudentSubject",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                schema: "core",
                table: "StudentSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectExam_ExamId",
                schema: "core",
                table: "StudentSubjectExam",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_FacultyId",
                schema: "core",
                table: "Subject",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectProgram_SubjectId",
                schema: "core",
                table: "SubjectProgram",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_User_LecturerId",
                schema: "core",
                table: "User",
                column: "LecturerId",
                unique: true,
                filter: "[LecturerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_StudentId",
                schema: "core",
                table: "User",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LecturerSubject",
                schema: "core");

            migrationBuilder.DropTable(
                name: "StudentSubject",
                schema: "core");

            migrationBuilder.DropTable(
                name: "StudentSubjectExam",
                schema: "core");

            migrationBuilder.DropTable(
                name: "SubjectProgram",
                schema: "core");

            migrationBuilder.DropTable(
                name: "User",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Exam",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Lecturer",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Subject",
                schema: "core");

            migrationBuilder.DropTable(
                name: "Faculty",
                schema: "core");
        }
    }
}
