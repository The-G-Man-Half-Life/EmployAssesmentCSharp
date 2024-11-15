using EmployAssesmentCSharp.Models;

namespace EmployAssesmentCSharp.Repositories.Interfaces;
public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetAll();
    Task<Doctor?> GetById(int id);
    Task Add(Doctor Doctor);
    Task Update(Doctor Doctor);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}