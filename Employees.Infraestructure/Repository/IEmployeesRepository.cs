using Employees.Domain.Models;

namespace Employees.Infraestructure.Repository
{
    /// <summary>
    ///
    /// </summary>
    public interface IEmployeesRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Employee> GetEmployeeById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Employee>> GetAllEmployees();
    }
}