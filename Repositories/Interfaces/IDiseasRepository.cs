using EmployAssesmentCSharp.Models;

namespace EmployAssesmentCSharp.Repositories.Interfaces;
public interface IDiseasRepository
{
    Task<IEnumerable<Diseas>> GetAll();
    Task<Diseas?> GetById(int id);
    Task Add(Diseas Diseas);
    Task Update(Diseas Diseas);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}