using EmployAssesmentCSharp.Data;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Services;
public class DoctorServices : IDoctorRepository
{
    private readonly ApplicationDbContext Context;

    public DoctorServices(ApplicationDbContext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Doctor>> GetAll()
    {
        try
        {
            return await Context.Doctors.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task<Doctor> GetById(int id)
    {
        try
        {
            return await Context.Doctors.FirstOrDefaultAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Add(Doctor Doctor)
    {
        try
        {
            await Context.Doctors.AddAsync(Doctor);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Update(Doctor Doctor)
    {
        try
        {
            Context.Doctors.Update(Doctor);
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
            Context.Doctors.Remove(roomTypeFound);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task <bool> CheckExistence(int id)
    {
        return await Context.Doctors.AnyAsync(b=>b.Id == id);
    }
}