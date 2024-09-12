using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NTierArchitecture.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 12, 22, 40, 24, 773, DateTimeKind.Local).AddTicks(857), "Information Technology", false, "IT" },
                    { 2, new DateTime(2024, 9, 12, 22, 40, 24, 773, DateTimeKind.Local).AddTicks(871), "Human Resources", false, "HR" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo", new DateTime(2024, 9, 12, 22, 40, 24, 773, DateTimeKind.Local).AddTicks(960), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Saher Said Fahd" },
                    { 2, "Cairo", new DateTime(2024, 9, 12, 22, 40, 24, 773, DateTimeKind.Local).AddTicks(964), new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ahmed " },
                    { 3, "Cairo", new DateTime(2024, 9, 12, 22, 40, 24, 773, DateTimeKind.Local).AddTicks(966), new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ali" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_Name",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
