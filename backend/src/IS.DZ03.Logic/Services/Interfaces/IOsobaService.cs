using IS.DZ03.Logic.Requests;
using IS.DZ03.Logic.Results;
using Sieve.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services.Interfaces
{
    public interface IOsobaService
    {
        Task<IEnumerable<EmployeeInfoResult>> GetAllEmployees(SieveModel model);
        Task<OsobaResult> AddEmployee(OsobaRequest employee);
        Task<OsobaResult> EditEmployee(string oib, OsobaRequest employee);
        Task DeleteEmployee(string oib);

        Task<IEnumerable<CustomerSupportInfoResult>> GetAllCustomerSupport();
    }
}
