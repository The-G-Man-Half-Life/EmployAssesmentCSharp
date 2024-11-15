using EmployAssesmentCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Data;
public class ApplicationDbContext:DbContext
{
    public DbSet<Diseas> Diseases {get; set;}
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}