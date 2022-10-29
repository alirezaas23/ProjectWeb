using ProjectWeb.Domain.Models.SiteSetting;
using System.Threading.Tasks;

namespace ProjectWeb.Domain.Interfaces
{
    public interface ISiteSettingRepository
    {
        Task<EmailSetting> GetDefaultEmail();
    }
}
