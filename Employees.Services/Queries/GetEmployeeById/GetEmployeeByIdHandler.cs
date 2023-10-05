using Employees.Domain.Requests;
using Employees.Domain.Responses;
using Employees.Infraestructure.Repository;
using MediatR;

namespace Employees.Services.Queries.GetEmployeeById
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {

        private readonly IEmployeesRepository _employeesRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeesRepository"></param>
        public GetEmployeeByIdHandler(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var response = await _employeesRepository.GetEmployeeById(request.Id);

            GetEmployeeByIdResponse employee;

            response.AnnualSalary = CalculateAnnualSalary(response.Salary);

            employee = new GetEmployeeByIdResponse
            {
                Employee = response
            };

            return employee;
        }

        private double CalculateAnnualSalary(double salary)
        {
            var annualSalary = salary * 12;

            return annualSalary;
        }
    }
}
