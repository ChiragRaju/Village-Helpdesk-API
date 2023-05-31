using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HelpDesk.Domain.Migrations
{
    /// <inheritdoc />
    public partial class status : Migration
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
                name: "localUsersDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localUsersDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_localUsersDb_adminDB_AdminId",
                        column: x => x.AdminId,
                        principalTable: "adminDB",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_localUsersDb_usersDB_UserId",
                        column: x => x.UserId,
                        principalTable: "usersDB",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "issueDB",
                columns: table => new
                {
                    IssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issueDB", x => x.IssueId);
                    table.ForeignKey(
                        name: "FK_issueDB_adminDB_AdminId",
                        column: x => x.AdminId,
                        principalTable: "adminDB",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "FK_issueDB_statusDB_StatusId",
                        column: x => x.StatusId,
                        principalTable: "statusDB",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_issueDB_usersDB_UserId",
                        column: x => x.UserId,
                        principalTable: "usersDB",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_issueDB_workerDB_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "workerDB",
                        principalColumn: "WorkerId");
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
                        name: "FK_feedbackDB_issueDB_IssueId",
                        column: x => x.IssueId,
                        principalTable: "issueDB",
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
                    { 1, "shanu548115@", 1, new DateTime(2023, 5, 30, 16, 20, 23, 785, DateTimeKind.Local).AddTicks(5485), "shanu@gmail.com", 1, new DateTime(2023, 5, 30, 16, 20, 23, 785, DateTimeKind.Local).AddTicks(5500), "Shanu Kumar", "shanu548115@" },
                    { 2, "sid@", 2, new DateTime(2023, 5, 30, 16, 20, 23, 785, DateTimeKind.Local).AddTicks(5513), "sid@gmail.com", 1, new DateTime(2023, 5, 30, 16, 20, 23, 785, DateTimeKind.Local).AddTicks(5515), "Siddhant Kashyap", "sid@" }
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
                name: "IX_issueDB_AdminId",
                table: "issueDB",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_issueDB_StatusId",
                table: "issueDB",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_issueDB_UserId",
                table: "issueDB",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_issueDB_WorkerId",
                table: "issueDB",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_localUsersDb_AdminId",
                table: "localUsersDb",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_localUsersDb_UserId",
                table: "localUsersDb",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbackDB");

            migrationBuilder.DropTable(
                name: "localUsersDb");

            migrationBuilder.DropTable(
                name: "issueDB");

            migrationBuilder.DropTable(
                name: "adminDB");

            migrationBuilder.DropTable(
                name: "statusDB");

            migrationBuilder.DropTable(
                name: "usersDB");

            migrationBuilder.DropTable(
                name: "workerDB");
        }
    }
}
