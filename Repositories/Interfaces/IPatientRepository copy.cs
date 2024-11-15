using EmployAssesmentCSharp.Models;

namespace EmployAssesmentCSharp.Repositories.Interfaces;
public interface IPatientRepository
{
    Task<IEnumerable<Patient>> GetAll();
    Task<Patient?> GetById(int id);
    Task Add(Patient Patient);
    Task Update(Patient Patient);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}