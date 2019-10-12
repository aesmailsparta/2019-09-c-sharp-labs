using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_48_api_todo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    TaskItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: false),
                    TaskDone = table.Column<bool>(nullable: false),
                    DateDue = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.TaskItemID);
                    table.ForeignKey(
                        name: "FK_TaskItems_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItems_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[] { 1, "Holiday Packing", "Items to pack for my holiday" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[] { 2, "Daily Tasks", "List of to do items for today" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[] { 3, "Thoughts", "List of my thoughts to create" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Name", "Username" },
                values: new object[] { 1, "SpartaBoy", "Spartan" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Name", "Username" },
                values: new object[] { 2, "Terrance", "Trainee" });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "CategoryID", "DateDue", "Description", "TaskDone", "UserID" },
                values: new object[] { 1, 1, new DateTime(2019, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "My First Task", false, 1 });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "CategoryID", "DateDue", "Description", "TaskDone", "UserID" },
                values: new object[] { 2, 1, new DateTime(2019, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Second Task", false, 1 });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "CategoryID", "DateDue", "Description", "TaskDone", "UserID" },
                values: new object[] { 3, 2, new DateTime(2019, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Third Task", false, 1 });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "CategoryID", "DateDue", "Description", "TaskDone", "UserID" },
                values: new object[] { 4, 2, new DateTime(2019, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Fourth Task", false, 1 });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "TaskItemID", "CategoryID", "DateDue", "Description", "TaskDone", "UserID" },
                values: new object[] { 5, 3, new DateTime(2019, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Fifth Task", false, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_CategoryID",
                table: "TaskItems",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserID",
                table: "TaskItems",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
