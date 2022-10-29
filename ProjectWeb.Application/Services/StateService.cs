using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.ViewModels.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Application.Services
{
    public class StateService : IStateService
    {
        #region Ctor

        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        #endregion
        public async Task<List<SelectListViewModel>> GetAllStates(long? parentId = null)
        {
            var result = await _stateRepository.GetAllStates(parentId);

            return result.Select(s => new SelectListViewModel()
            {
                Id = s.Id,
                Title = s.Title
            })
                .ToList();
        }
    }
}
