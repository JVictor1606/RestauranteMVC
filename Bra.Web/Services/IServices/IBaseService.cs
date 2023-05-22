using Bra.Web.Models;

namespace Bra.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseMOdel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
