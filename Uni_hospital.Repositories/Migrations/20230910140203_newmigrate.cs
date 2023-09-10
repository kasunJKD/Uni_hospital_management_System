using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_hospital.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class newmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedMedicine_Medicine_MedicineId",
                table: "PrescribedMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedMedicine_PatientReports_PatientReportId",
                table: "PrescribedMedicine");

            migrationBuilder.AlterColumn<int>(
                name: "PatientReportId",
                table: "PrescribedMedicine",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "PrescribedMedicine",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "PatientReports",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "PatientReports",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Diagnose",
                table: "PatientReports",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Medicine",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Medicine",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Medicine",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedMedicine_Medicine_MedicineId",
                table: "PrescribedMedicine",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedMedicine_PatientReports_PatientReportId",
                table: "PrescribedMedicine",
                column: "PatientReportId",
                principalTable: "PatientReports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedMedicine_Medicine_MedicineId",
                table: "PrescribedMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedMedicine_PatientReports_PatientReportId",
                table: "PrescribedMedicine");

            migrationBuilder.AlterColumn<int>(
                name: "PatientReportId",
                table: "PrescribedMedicine",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "PrescribedMedicine",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "PatientReports",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "PatientReports",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diagnose",
                table: "PatientReports",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Medicine",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Medicine",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Medicine",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedMedicine_Medicine_MedicineId",
                table: "PrescribedMedicine",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedMedicine_PatientReports_PatientReportId",
                table: "PrescribedMedicine",
                column: "PatientReportId",
                principalTable: "PatientReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
