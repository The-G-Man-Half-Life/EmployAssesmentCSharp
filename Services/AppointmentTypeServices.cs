using EmployAssesmentCSharp.Data;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Services;
public class AppointmentTypeServices : IAppointmentTypeRepository
{
    private readonly ApplicationDbContext Context;

    public AppointmentTypeServices(ApplicationDbContext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<AppointmentType>> GetAll()
    {
        try
        {
            return await Context.AppointmentTypes.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task<AppointmentType> GetById(int id)
    {
        try
        {
            return await Context.AppointmentTypes.FirstOrDefaultAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Add(AppointmentType AppointmentType)
    {
        try
        {
            await Context.AppointmentTypes.AddAsync(AppointmentType);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Update(AppointmentType AppointmentType)
    {
        try
        {
            Context.AppointmentTypes.Update(AppointmentType);
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
            Context.AppointmentTypes.Remove(roomTypeFound);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task <bool> CheckExistence(int id)
    {
        return await Context.AppointmentTypes.AnyAsync(b=>b.Id == id);
    }
}