using Microsoft.EntityFrameworkCore;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models.SiteSetting;
using ProjectWeb.Infra.Data.Context;
using System.Threading.Tasks;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class SiteSettingRepository : ISiteSettingRepository
    {
        #region Ctor

        private readonly ApplicationContext _context;

        public SiteSettingRepository(ApplicationContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<EmailSetting> GetDefaultEmail()
        {
            return await _context.EmailSettings.SingleOrDefaultAsync(e => e.IsDefault && !e.IsDelete);
        }
    }
}
