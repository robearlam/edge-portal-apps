using EdgePortalApps.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdgePortalApps.Data.Services
{
    public interface INewsService
    {
        Task<List<NewsArticle>> GetTopNewsArticles(int count = 4);
    }
}
