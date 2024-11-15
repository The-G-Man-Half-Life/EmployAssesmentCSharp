using Bogus;
using EmployAssesmentCSharp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CSharpTest.Seeders
{
    public class DiseasSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var diseases = GenerateDiseases(10);  // Generar 10 enfermedades
            modelBuilder.Entity<Diseas>().HasData(diseases);
        }

        public static IEnumerable<Diseas> GenerateDiseases(int count)
        {
            var faker = new Faker<Diseas>()
                .RuleFor(d => d.Id, f => f.IndexFaker+1)  // Id generado de manera única
                .RuleFor(d => d.Name, f => f.PickRandom("Gripe", "Diabetes", "Hipertensión", "Cáncer", "Asma", "Neumonía", "Covid-19", "Artritis", "EPOC", "Insuficiencia Renal"))
                .RuleFor(d => d.Description, f => f.Lorem.Sentence());  // Genera una descripción aleatoria

            return faker.Generate(count);
        }
    }
}
