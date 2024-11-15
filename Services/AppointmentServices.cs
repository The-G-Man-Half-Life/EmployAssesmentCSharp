using CSharpTest.Models;
using EmployAssesmentCSharp.Data;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Services;
public class AppointmentServices : IAppointmentRepository
{
    private readonly ApplicationDbContext Context;

    public AppointmentServices(ApplicationDbContext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Appointment>> GetAll()
    {
        try
        {
            return await Context.Appointments.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task<Appointment> GetById(int id)
    {
        try
        {
            return await Context.Appointments.FirstOrDefaultAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Add(Appointment Appointment)
    {
        try
        {
            await Context.Appointments.AddAsync(Appointment);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Update(Appointment Appointment)
    {
        try
        {
            Context.Appointments.Update(Appointment);
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
            Context.Appointments.Remove(roomTypeFound);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task <bool> CheckExistence(int id)
    {
        return await Context.Appointments.AnyAsync(b=>b.Id == id);
    }
}