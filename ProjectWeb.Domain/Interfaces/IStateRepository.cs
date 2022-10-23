using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectWeb.Domain.Models.Location;
using ProjectWeb.Domain.ViewModels.Common;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllStates(long? parentId = null);
    }
}
