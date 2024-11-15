using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployAssesmentCSharp.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTheappointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    start_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    diseas_id = table.Column<int>(type: "int", nullable: false),
                    appointment_type_id = table.Column<int>(type: "int", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentType_appointment_type_id",
                        column: x => x.appointment_type_id,
                        principalTable: "AppointmentType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Diseases_diseas_id",
                        column: x => x.diseas_id,
                        principalTable: "Diseases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_appointment_type_id",
                table: "Appointments",
                column: "appointment_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_diseas_id",
                table: "Appointments",
                column: "diseas_id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_doctor_id",
                table: "Appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_patient_id",
                table: "Appointments",
                column: "patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
