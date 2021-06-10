using EdgePortalApps.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdgePortalApps.Data.Services
{
    public interface IAnnouncementsService
    {
        Task<List<Announcement>> GetTopAnnouncements(int count = 3);
    }
}
