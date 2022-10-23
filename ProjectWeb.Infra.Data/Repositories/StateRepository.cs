using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models.Location;
using ProjectWeb.Domain.ViewModels.Common;
using ProjectWeb.Infra.Data.Context;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class StateRepository : IStateRepository
    {
        #region Ctor

        private readonly ApplicationContext _context;

        public StateRepository(ApplicationContext context)
        {
            _context = context;
        }

        #endregion
        public async Task<List<State>> GetAllStates(long? parentId = null)
        {
            var states = _context.States.Where(s => !s.IsDelete).AsQueryable();

            states = parentId.HasValue ? states.Where(s => s.ParentId.HasValue && s.ParentId == parentId.Value) : states.Where(s => s.ParentId == null);

            return await states.ToListAsync();
        }
    }
}
