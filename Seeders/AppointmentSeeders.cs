using Bogus;
using CSharpTest.Models;
using EmployAssesmentCSharp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CSharpTest.Seeders
{
    public class AppointmentSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var appointments = GenerateAppointments(10);  // Generar 10 citas
            modelBuilder.Entity<Appointment>().HasData(appointments);
        }

        public static IEnumerable<Appointment> GenerateAppointments(int count)
        {
            var faker = new Faker<Appointment>()
                .RuleFor(a => a.Id, f => f.IndexFaker+1)  // Id generado de manera única
                .RuleFor(a => a.StartTime, f => GenerateUniqueStartTime(f))
                .RuleFor(a => a.EndTime, (f, a) => a.StartTime.AddMinutes(f.Random.Int(30, 120))) // Fin de cita entre 30 y 120 minutos después
                .RuleFor(a => a.Reason, f => f.Lorem.Sentence())
                .RuleFor(a => a.DiseasId, f => f.Random.Int(1, 5))  // Asegúrate de que existan enfermedades en tu base de datos
                .RuleFor(a => a.AppointmentTypeId, f => f.Random.Int(1, 3))  // Asegúrate de que existan tipos de cita
                .RuleFor(a => a.PatientId, f => f.Random.Int(1, 5))  // Asegúrate de que existan pacientes en tu base de datos
                .RuleFor(a => a.DoctorId, f => f.Random.Int(1, 5));  // Asegúrate de que existan doctores en tu base de datos

            return faker.Generate(count);
        }

        // Genera un StartTime único para evitar solapamientos
        private static DateTime GenerateUniqueStartTime(Faker f)
        {
            var baseTime = DateTime.Now.AddDays(f.Random.Int(1, 30));  // Empezar dentro de los próximos 30 días
            var randomStart = baseTime.AddMinutes(f.Random.Int(0, 1440));  // Generar un tiempo aleatorio dentro del día

            return randomStart;
        }
    }
}
