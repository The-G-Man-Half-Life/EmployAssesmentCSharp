using Bogus;
using EmployAssesmentCSharp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CSharpTest.Seeders
{
    public class PatientSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var patients = GeneratePatients(10);  // Generar 10 pacientes
            modelBuilder.Entity<Patient>().HasData(patients);
        }

        public static IEnumerable<Patient> GeneratePatients(int count)
        {
            var faker = new Faker<Patient>()
                .RuleFor(p => p.Id, f => f.IndexFaker+1)  // Id generado de manera única
                .RuleFor(p => p.Name, f => f.Name.FullName())  // Nombre completo aleatorio
                .RuleFor(p => p.IdentificationNumber, f => f.Random.Int(1000000, 9999999).ToString())  // Número de identificación aleatorio
                .RuleFor(p => p.Email, f => f.Internet.Email())  // Correo electrónico aleatorio
                .RuleFor(p => p.Password, f => f.Internet.Password())  // Contraseña aleatoria
                ;

            return faker.Generate(count);
        }
    }
}
