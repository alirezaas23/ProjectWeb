using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectWeb.Domain.ViewModels.Common;

namespace ProjectWeb.Application.Interfaces
{
    public interface IStateService
    {
        Task<List<SelectListViewModel>> GetAllStates(long? parentId = null);
    }
}
