using IS.DZ03.Logic.Requests;
using IS.DZ03.Logic.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Services.Interfaces
{
    public interface IZadatakService
    {
        Task<IList<ZadatakInfoResult>> GetEmployeeTasks(long employeeID);
        Task<ZadatakResult> CreateTask(ZadatakRequest task);
        Task<ZadatakResult> UpdateTask(int taskID, ZadatakRequest task);
        Task DeleteTask(int taskID);
    }
}
