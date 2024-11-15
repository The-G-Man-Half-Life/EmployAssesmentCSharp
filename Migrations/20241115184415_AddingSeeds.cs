using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployAssesmentCSharp.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppointmentType",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Consequatur velit quis dolor et.", "Chequeo Preventivo" },
                    { 2, "Aperiam natus temporibus similique.", "Consulta General" },
                    { 3, "Amet quam voluptatem cumque recusandae.", "Chequeo Preventivo" },
                    { 4, "Impedit architecto quasi rerum aut quae.", "Chequeo Preventivo" },
                    { 5, "Repellat quas placeat ea eos fuga omnis illum quisquam.", "Consulta General" }
                });

            migrationBuilder.InsertData(
                table: "Diseases",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Sit tenetur quod dolorum sunt cupiditate magnam eveniet itaque.", "EPOC" },
                    { 2, "Dolor explicabo cum dolores aliquid rerum veritatis aut qui officia.", "Diabetes" },
                    { 3, "Quo quas autem.", "Neumonía" },
                    { 4, "Consequuntur inventore praesentium adipisci impedit quia atque dicta.", "Artritis" },
                    { 5, "Error dolorem aspernatur deserunt.", "Gripe" },
                    { 6, "Facilis est omnis consequuntur aut.", "Insuficiencia Renal" },
                    { 7, "Et similique aut cum exercitationem.", "Cáncer" },
                    { 8, "Inventore facere asperiores sit aliquam nihil quia aperiam consectetur enim.", "Asma" },
                    { 9, "Porro non consequatur velit temporibus.", "EPOC" },
                    { 10, "Nostrum asperiores quas molestiae.", "Gripe" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "id", "email", "end_time", "identification_number", "name", "password", "specialty", "start_time" },
                values: new object[,]
                {
                    { 1, "Branson83@yahoo.com", new TimeSpan(0, 16, 0, 0, 0), "2895019", "Noelia Spencer", "ULVTHy0ZPQ", "Cardiology", new TimeSpan(0, 12, 0, 0, 0) },
                    { 2, "Trever_Ruecker12@gmail.com", new TimeSpan(0, 13, 0, 0, 0), "2512693", "Lavinia Cronin", "9mgZlIj6AO", "General Surgery", new TimeSpan(0, 9, 0, 0, 0) },
                    { 3, "Tyreek_Balistreri47@gmail.com", new TimeSpan(0, 17, 0, 0, 0), "4416555", "Assunta Lindgren", "8XJJfeqNGg", "Neurology", new TimeSpan(0, 9, 0, 0, 0) },
                    { 4, "Clemmie_Harber76@hotmail.com", new TimeSpan(0, 13, 0, 0, 0), "5404316", "Gust Grant", "AhkMN112WY", "Cardiology", new TimeSpan(0, 9, 0, 0, 0) },
                    { 5, "Dangelo_Lueilwitz@hotmail.com", new TimeSpan(0, 17, 0, 0, 0), "8980260", "Maya Ryan", "NPXaeLZ1Oj", "Orthopedics", new TimeSpan(0, 10, 0, 0, 0) },
                    { 6, "Nicola.Larson96@yahoo.com", new TimeSpan(0, 15, 0, 0, 0), "4572758", "Jarret Huels", "8LqMH7T6s9", "Orthopedics", new TimeSpan(0, 8, 0, 0, 0) },
                    { 7, "Ada.Heller94@hotmail.com", new TimeSpan(0, 13, 0, 0, 0), "2010250", "Waylon O'Keefe", "8IFjySoNB1", "Neurology", new TimeSpan(0, 9, 0, 0, 0) },
                    { 8, "Jacques.Cormier@gmail.com", new TimeSpan(0, 14, 0, 0, 0), "8792763", "Quinten Bogan", "3WKYzrYKZn", "Neurology", new TimeSpan(0, 10, 0, 0, 0) },
                    { 9, "Karlie_Wisozk98@hotmail.com", new TimeSpan(0, 17, 0, 0, 0), "8122699", "Howell Prosacco", "SW1dFpW8f9", "General Surgery", new TimeSpan(0, 9, 0, 0, 0) },
                    { 10, "Jeromy.Legros58@gmail.com", new TimeSpan(0, 16, 0, 0, 0), "7469628", "Madonna Roob", "fei5BN3wx6", "General Surgery", new TimeSpan(0, 8, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "email", "identification_number", "name", "password" },
                values: new object[,]
                {
                    { 1, "Ruthie41@yahoo.com", "9544179", "Rigoberto McGlynn", "EdVDoBUknv" },
                    { 2, "Daisha_Stanton30@gmail.com", "7846039", "Charlie Wolf", "0yybUcOYZw" },
                    { 3, "Carolanne_Schultz39@hotmail.com", "1315007", "Reggie Mraz", "JZqXMpwZkh" },
                    { 4, "Carole12@yahoo.com", "8739325", "Giovanni Gusikowski", "u8WL4aCQqt" },
                    { 5, "Hilario6@hotmail.com", "5759409", "Joel Watsica", "26Iuv7BWah" },
                    { 6, "Drake_Jacobs@hotmail.com", "3157891", "Felipe Abbott", "DN0otwkcSX" },
                    { 7, "Genesis_Hansen@gmail.com", "5435463", "Forrest Abernathy", "G7EO2UcQ3j" },
                    { 8, "Ferne.Bernier61@yahoo.com", "8546769", "Aditya Stanton", "jXvwCNOm97" },
                    { 9, "Sabrina11@hotmail.com", "8776299", "Hank Runolfsson", "DpWHurmv8X" },
                    { 10, "Esperanza.Kunde38@gmail.com", "6165654", "Jackson Hyatt", "Z9bMqk2Bo_" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "id", "appointment_type_id", "diseas_id", "doctor_id", "end_time", "patient_id", "reason", "start_time" },
                values: new object[,]
                {
                    { 1, 3, 1, 1, new DateTime(2024, 12, 10, 5, 27, 15, 260, DateTimeKind.Local).AddTicks(533), 4, "Enim maiores sunt quia dolor est neque sunt aut.", new DateTime(2024, 12, 10, 4, 27, 15, 260, DateTimeKind.Local).AddTicks(533) },
                    { 2, 3, 3, 5, new DateTime(2024, 12, 7, 3, 0, 15, 260, DateTimeKind.Local).AddTicks(1926), 5, "Aut et eum voluptatem recusandae voluptas ullam sunt illo eveniet.", new DateTime(2024, 12, 7, 1, 54, 15, 260, DateTimeKind.Local).AddTicks(1926) },
                    { 3, 3, 5, 3, new DateTime(2024, 11, 24, 5, 7, 15, 260, DateTimeKind.Local).AddTicks(2016), 5, "Laudantium sequi sed ullam voluptas eum qui.", new DateTime(2024, 11, 24, 3, 11, 15, 260, DateTimeKind.Local).AddTicks(2016) },
                    { 4, 2, 1, 3, new DateTime(2024, 11, 20, 2, 5, 15, 260, DateTimeKind.Local).AddTicks(2047), 1, "Consequatur quia id delectus fuga quis natus.", new DateTime(2024, 11, 20, 0, 13, 15, 260, DateTimeKind.Local).AddTicks(2047) },
                    { 5, 1, 5, 3, new DateTime(2024, 11, 28, 19, 43, 15, 260, DateTimeKind.Local).AddTicks(2078), 5, "Cum cumque et voluptatum minima veniam.", new DateTime(2024, 11, 28, 18, 34, 15, 260, DateTimeKind.Local).AddTicks(2078) },
                    { 6, 2, 2, 1, new DateTime(2024, 12, 9, 4, 57, 15, 260, DateTimeKind.Local).AddTicks(2106), 4, "Molestiae sapiente corporis debitis temporibus quia minus sunt voluptatem amet.", new DateTime(2024, 12, 9, 3, 31, 15, 260, DateTimeKind.Local).AddTicks(2106) },
                    { 7, 2, 3, 3, new DateTime(2024, 12, 4, 2, 15, 15, 260, DateTimeKind.Local).AddTicks(2142), 4, "Eum impedit sapiente corrupti quisquam assumenda cumque.", new DateTime(2024, 12, 4, 1, 9, 15, 260, DateTimeKind.Local).AddTicks(2142) },
                    { 8, 3, 3, 1, new DateTime(2024, 12, 2, 14, 31, 15, 260, DateTimeKind.Local).AddTicks(2240), 4, "Aut est ut consectetur et minima incidunt repudiandae earum.", new DateTime(2024, 12, 2, 13, 23, 15, 260, DateTimeKind.Local).AddTicks(2240) },
                    { 9, 3, 3, 3, new DateTime(2024, 11, 28, 4, 45, 15, 260, DateTimeKind.Local).AddTicks(2276), 1, "Dolorem ab non eos praesentium corrupti impedit perferendis vel.", new DateTime(2024, 11, 28, 3, 24, 15, 260, DateTimeKind.Local).AddTicks(2276) },
                    { 10, 3, 4, 1, new DateTime(2024, 12, 1, 1, 28, 15, 260, DateTimeKind.Local).AddTicks(2310), 1, "Error at et rerum aliquid et consequatur animi.", new DateTime(2024, 11, 30, 23, 48, 15, 260, DateTimeKind.Local).AddTicks(2310) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppointmentType",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AppointmentType",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AppointmentType",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppointmentType",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppointmentType",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diseases",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
