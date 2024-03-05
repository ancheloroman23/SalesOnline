using SalesOnline.Application.Dtos.Base;
using SalesOnline.Web.Models.Responses;

namespace SalesOnline.Web.Services
{
    public interface IWebService
    {       
        public BaseResponse<T> GetDataFromApi<T>(string apiUrl);
        public T PostDataToApi<T>(string apiUrl, DtoBase data);
    }
}
