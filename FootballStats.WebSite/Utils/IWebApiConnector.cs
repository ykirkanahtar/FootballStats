using System.Threading.Tasks;

namespace FootballStats.WebSite.Utils
{
    public interface IWebApiConnector
    {
        Task<WebApiResponse> GetAsync(string getUrl, string token = null);

        Task<WebApiResponse> PostAsync(string requestPath, string jsonContent, string token = null);

    }
}