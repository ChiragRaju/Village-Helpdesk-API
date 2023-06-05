using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HelpDesk.Domain.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminDB",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminDB", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "statusDB",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusDB", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "usersDB",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersDB", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "workerDB",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workerDB", x => x.WorkerId);
                });

            migrationBuilder.CreateTable(
                name: "issueDb",
                columns: table => new
                {
                    IssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRefId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issueDb", x => x.IssueId);
                    table.ForeignKey(
                        name: "FK_issueDb_usersDB_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "usersDB",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedbackDB",
                columns: table => new
                {
                    FeedBackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    IssueId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbackDB", x => x.FeedBackId);
                    table.ForeignKey(
                        name: "FK_feedbackDB_issueDb_IssueId",
                        column: x => x.IssueId,
                        principalTable: "issueDb",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedbackDB_statusDB_StatusId",
                        column: x => x.StatusId,
                        principalTable: "statusDB",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedbackDB_usersDB_UserId",
                        column: x => x.UserId,
                        principalTable: "usersDB",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "adminDB",
                columns: new[] { "AdminId", "ConfirmPassword", "CreatedBy", "CreatedOn", "Email", "ModifiedBy", "ModifiedOn", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "shanu548115@", 1, new DateTime(2023, 6, 5, 16, 14, 41, 528, DateTimeKind.Local).AddTicks(6999), "shanu@gmail.com", 1, new DateTime(2023, 6, 5, 16, 14, 41, 528, DateTimeKind.Local).AddTicks(7014), "Shanu Kumar", "shanu548115@" },
                    { 2, "sid@", 2, new DateTime(2023, 6, 5, 16, 14, 41, 528, DateTimeKind.Local).AddTicks(7019), "sid@gmail.com", 1, new DateTime(2023, 6, 5, 16, 14, 41, 528, DateTimeKind.Local).AddTicks(7020), "Siddhant Kashyap", "sid@" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_feedbackDB_IssueId",
                table: "feedbackDB",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbackDB_StatusId",
                table: "feedbackDB",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbackDB_UserId",
                table: "feedbackDB",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_issueDb_UserRefId",
                table: "issueDb",
                column: "UserRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminDB");

            migrationBuilder.DropTable(
                name: "feedbackDB");

            migrationBuilder.DropTable(
                name: "workerDB");

            migrationBuilder.DropTable(
                name: "issueDb");

            migrationBuilder.DropTable(
                name: "statusDB");

            migrationBuilder.DropTable(
                name: "usersDB");
        }
    }
}
