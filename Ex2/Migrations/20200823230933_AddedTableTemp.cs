using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ex2.Migrations
{
    public partial class AddedTableTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    PhoneNumber = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 20, nullable: true),
                    PayRate = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTemp",
                columns: table => new
                {
                    EmployeeTempID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PayRate = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTemp", x => x.EmployeeTempID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(maxLength: 10, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Note = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "TaskTemp",
                columns: table => new
                {
                    TaskTempID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: true),
                    ProjectID = table.Column<int>(nullable: true),
                    WorkingHours = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTemp", x => x.TaskTempID);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: true),
                    ProjectID = table.Column<int>(nullable: true),
                    WorkingHours = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Task_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeID", "Address", "DateOfBirth", "Email", "FullName", "PayRate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Hanoi", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a@yahoo.com", "A A", 7f, "0912345678" },
                    { 2, "Hanoi", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b@yahoo.com", "B B", 12f, "0912345678" },
                    { 3, "Hanoi", new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c@yahoo.com", "C C", 10.5f, "0912345678" },
                    { 4, "Hanoi", new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d@yahoo.com", "D D", 5.4f, "0912345678" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectID", "Description", "Note", "ProjectName" },
                values: new object[,]
                {
                    { 1, "1", "1", "Project1" },
                    { 2, "2", "2", "Project2" },
                    { 3, "3", "3", "Project3" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskID", "EmployeeID", "ProjectID", "WorkingHours" },
                values: new object[] { 1, 1, 1, 50 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskID", "EmployeeID", "ProjectID", "WorkingHours" },
                values: new object[] { 2, 2, 2, 33 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskID", "EmployeeID", "ProjectID", "WorkingHours" },
                values: new object[] { 3, 3, 3, 77 });

            migrationBuilder.CreateIndex(
                name: "IX_Task_EmployeeID",
                table: "Task",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectID",
                table: "Task",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTemp");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TaskTemp");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
