using IS.DZ03.Logic.Results;
using Sieve.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services.Interfaces
{
    public interface IOsobaService
    {
        Task<IEnumerable<EmployeeInfoResult>> GetAllEmployees(SieveModel model);

        Task<IEnumerable<CustomerSupportInfoResult>> GetAllCustomerSupport();
    }
}
