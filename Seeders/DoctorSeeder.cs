using Bogus;
using EmployAssesmentCSharp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CSharpTest.Seeders
{
    public class DoctorSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var doctors = GenerateDoctors(10);  // Generar 10 doctores
            modelBuilder.Entity<Doctor>().HasData(doctors);
        }

        public static IEnumerable<Doctor> GenerateDoctors(int count)
        {
            var faker = new Faker<Doctor>()
                .RuleFor(d => d.Id, f => f.IndexFaker+1)  // Id generado de manera única
                .RuleFor(d => d.Name, f => f.Name.FullName())  // Nombre completo aleatorio
                .RuleFor(d => d.IdentificationNumber, f => f.Random.Int(1000000, 9999999).ToString())  // Número de identificación aleatorio
                .RuleFor(d => d.Email, f => f.Internet.Email())  // Correo electrónico aleatorio
                .RuleFor(d => d.Password, f => f.Internet.Password())  // Contraseña aleatoria
                .RuleFor(d => d.Specialty, f => f.PickRandom("Cardiology", "Neurology", "Orthopedics", "Pediatrics", "General Surgery"))  // Especialidad aleatoria
                .RuleFor(d => d.StartTime, f => TimeSpan.FromHours(f.Random.Int(8, 12)))  // Hora de inicio aleatoria (entre 8 AM y 12 PM)
                .RuleFor(d => d.EndTime, f => TimeSpan.FromHours(f.Random.Int(13, 18)))  // Hora de fin aleatoria (entre 1 PM y 6 PM)
                ;

            return faker.Generate(count);
        }
    }
}
