using Employees.Domain.Requests;
using Employees.Domain.Responses;
using Employees.Infraestructure.Repository;
using MediatR;

namespace Employees.Services.Queries.GetAllEmployees
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesRequest, GetAllEmployeesResponse>
    {

        private readonly IEmployeesRepository _employeesRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeesRepository"></param>
        public GetAllEmployeesHandler(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetAllEmployeesResponse> Handle(GetAllEmployeesRequest request, CancellationToken cancellationToken)
        {
            var response = await _employeesRepository.GetAllEmployees();
            GetAllEmployeesResponse employeesList;

            employeesList = new GetAllEmployeesResponse
            {
                Employees = response
            };

            return employeesList;
        }
    }
}
