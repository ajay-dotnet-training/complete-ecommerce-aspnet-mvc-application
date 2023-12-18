using eMovies.Areas.WebSeriesArea.Data.ViewModels;
using eMovies.Data.ViewModels;
using eMovies.Models;
using System.Linq.Expressions;

namespace eMovies.Areas.WebSeriesArea.Data.Services
{
    public interface IWebSeriesService
    {
        Task<IEnumerable<WebSeries>> GetAllAsync(params Expression<Func<WebSeries, object>>[] includeProperties);
        Task<WebSeries> GetWebSeriesByIdAsync(int id);
        Task<NewWebSeriesDropDownVM> GetNewWebSereisDropdownsValues();
        Task AddNewWebSereiesAsync(WebSeriesVM data);
        Task UpdateWebSereiesAsync(WebSeriesVM data);
    }
}
