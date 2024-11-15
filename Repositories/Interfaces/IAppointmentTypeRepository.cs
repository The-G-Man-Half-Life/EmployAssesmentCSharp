using EmployAssesmentCSharp.Models;

namespace EmployAssesmentCSharp.Repositories.Interfaces;
public interface IAppointmentTypeRepository
{
    Task<IEnumerable<AppointmentType>> GetAll();
    Task<AppointmentType?> GetById(int id);
    Task Add(AppointmentType AppointmentType);
    Task Update(AppointmentType AppointmentType);
    Task Delete(int id);
    Task<bool> CheckExistence(int id);
}