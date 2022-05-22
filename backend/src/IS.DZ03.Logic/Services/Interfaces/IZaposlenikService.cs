using IS.DZ03.Logic.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services.Interfaces
{
    public interface IZaposlenikService
    {
        Task<IEnumerable<ZaposlenikResult>> GetAllEmployees();
    }
}
