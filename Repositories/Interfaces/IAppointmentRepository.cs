using CSharpTest.Models;
using EmployAssesmentCSharp.Models;

namespace EmployAssesmentCSharp.Repositories.Interfaces;
public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAll();
    Task<Appointment?> GetById(int id);
    Task Add(Appointment Appointment);
    Task Update(Appointment Appointment);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}