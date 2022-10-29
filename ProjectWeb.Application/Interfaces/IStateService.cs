using ProjectWeb.Domain.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Application.Interfaces
{
    public interface IStateService
    {
        Task<List<SelectListViewModel>> GetAllStates(long? parentId = null);
    }
}
