using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAttendenceFeature.Migrations
{
    /// <inheritdoc />
    public partial class addclassSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesSections_Classes_ClassesId",
                table: "ClassesSections");

            migrationBuilder.RenameColumn(
                name: "ClassesId",
                table: "ClassesSections",
                newName: "ClassId");

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "ClassesSections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesSections_Classes_ClassId",
                table: "ClassesSections",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassesSections_Classes_ClassId",
                table: "ClassesSections");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "ClassesSections",
                newName: "ClassesId");

            migrationBuilder.AlterColumn<string>(
                name: "Capacity",
                table: "ClassesSections",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesSections_Classes_ClassesId",
                table: "ClassesSections",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
