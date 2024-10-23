using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPGTRTraining.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AllSmallCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DeptId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "departments");

            migrationBuilder.RenameColumn(
                name: "UpBy",
                table: "employees",
                newName: "upby");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "employees",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "employees",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "employees",
                newName: "isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "employees",
                newName: "deptid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "employees",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "employees",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "employees",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employees",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DeptId",
                table: "employees",
                newName: "ix_employees_deptid");

            migrationBuilder.RenameColumn(
                name: "UpBy",
                table: "departments",
                newName: "upby");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "departments",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "departments",
                newName: "isdeleted");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "departments",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "departments",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_employees",
                table: "employees",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_departments",
                table: "departments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_employees_departments_deptid",
                table: "employees",
                column: "deptid",
                principalTable: "departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_departments_deptid",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "pk_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "pk_departments",
                table: "departments");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "Departments");

            migrationBuilder.RenameColumn(
                name: "upby",
                table: "Employees",
                newName: "UpBy");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Employees",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Employees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "Employees",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "deptid",
                table: "Employees",
                newName: "DeptId");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Employees",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Employees",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Employees",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_employees_deptid",
                table: "Employees",
                newName: "IX_Employees_DeptId");

            migrationBuilder.RenameColumn(
                name: "upby",
                table: "Departments",
                newName: "UpBy");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Departments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "Departments",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Departments",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Departments",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DeptId",
                table: "Employees",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
