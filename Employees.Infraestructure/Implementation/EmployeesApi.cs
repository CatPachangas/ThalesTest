using Employees.Domain.Models;
using Employees.Infraestructure.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text.Json;

namespace Employees.Infraestructure.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeesApi : IEmployeesRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAllEmployees()
        {
            var client = new RestClient("https://dummy.restapiexample.com/");
            var request = new RestRequest("api/v1/employees");
            var response = await client.ExecuteAsync<dynamic>(request);

            dynamic obj = JsonConvert.DeserializeObject(response.Content);
            var data = obj?.data;

            var formattedList = data.ToString().Trim().TrimStart('{').TrimEnd('}');
            var list = JsonConvert.DeserializeObject<List<Employee>>(formattedList);


            ///var employees = JsonConvert.DeserializeObject<List<Employee>>(list);
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeById(int id)
        {
            var data = await GetAllEmployees();
            var employee = data.Find(x => x.Id == id);

            return employee;
        }
    }
}
