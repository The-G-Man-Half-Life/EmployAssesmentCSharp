using EmployAssesmentCSharp.Data;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Services;
public class PatientServices : IPatientRepository
{
    private readonly ApplicationDbContext Context;

    public PatientServices(ApplicationDbContext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Patient>> GetAll()
    {
        try
        {
            return await Context.Patients.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task<Patient> GetById(int id)
    {
        try
        {
            return await Context.Patients.FirstOrDefaultAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Add(Patient Patient)
    {
        try
        {
            await Context.Patients.AddAsync(Patient);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Update(Patient Patient)
    {
        try
        {
            Context.Patients.Update(Patient);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            var roomTypeFound = await GetById(id);
            Context.Patients.Remove(roomTypeFound);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task <bool> CheckExistence(int id)
    {
        return await Context.Patients.AnyAsync(b=>b.Id == id);
    }
}