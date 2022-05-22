using IS.DZ03.Logic.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services.Interfaces
{
    public interface IZadatakService
    {
        Task<IList<ZadatakResult>> GetEmployeeTasks(long employeeID);
    }
}
