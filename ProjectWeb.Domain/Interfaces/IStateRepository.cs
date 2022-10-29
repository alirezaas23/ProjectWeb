using ProjectWeb.Domain.Models.Location;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllStates(long? parentId = null);
    }
}
