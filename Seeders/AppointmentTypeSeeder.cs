using Bogus;
using EmployAssesmentCSharp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CSharpTest.Seeders
{
    public class AppointmentTypeSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var appointmentTypes = GenerateAppointmentTypes(5);  // Generar 5 tipos de citas
            modelBuilder.Entity<AppointmentType>().HasData(appointmentTypes);
        }

        public static IEnumerable<AppointmentType> GenerateAppointmentTypes(int count)
        {
            var faker = new Faker<AppointmentType>()
                .RuleFor(a => a.Id, f => f.IndexFaker+1)  // Id generado de manera única
                .RuleFor(a => a.Name, f => f.PickRandom("Consulta General", "Emergencia", "Chequeo Preventivo", "Seguimiento", "Especialidad"))
                .RuleFor(a => a.Description, f => f.Lorem.Sentence());

            return faker.Generate(count);
        }
    }
}
