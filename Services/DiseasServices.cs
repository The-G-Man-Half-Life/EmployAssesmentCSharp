using EmployAssesmentCSharp.Data;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Services;
public class DiseasServices : IDiseasRepository
{
    private readonly ApplicationDbContext Context;

    public DiseasServices(ApplicationDbContext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Diseas>> GetAll()
    {
        try
        {
            return await Context.Diseases.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task<Diseas> GetById(int id)
    {
        try
        {
            return await Context.Diseases.FirstOrDefaultAsync(r => r.Id == id);
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Add(Diseas Diseas)
    {
        try
        {
            await Context.Diseases.AddAsync(Diseas);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task Update(Diseas Diseas)
    {
        try
        {
            Context.Diseases.Update(Diseas);
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
            Context.Diseases.Remove(roomTypeFound);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {

            throw new Exception("An error happened during the process", dbEX);
        }
    }

    public async Task <bool> CheckExistence(int id)
    {
        return await Context.Diseases.AnyAsync(b=>b.Id == id);
    }
}