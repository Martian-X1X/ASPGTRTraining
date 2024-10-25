using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPGTRTraining.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "desigid",
                table: "employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "designationid",
                table: "employees",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_employees_designationid",
                table: "employees",
                column: "designationid");

            migrationBuilder.AddForeignKey(
                name: "fk_employees_designations_designationid",
                table: "employees",
                column: "designationid",
                principalTable: "designations",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_designations_designationid",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "ix_employees_designationid",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "desigid",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "designationid",
                table: "employees");
        }
    }
}
