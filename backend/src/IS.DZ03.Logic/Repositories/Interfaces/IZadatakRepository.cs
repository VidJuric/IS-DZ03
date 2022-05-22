using IS.DZ03.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Repositories.Interfaces
{
    public interface IZadatakRepository : IGenericRepository<Zadatak>
    {
        Task<IList<Zadatak>> GetEmployeeTasks(long employeeID);
    }
}
