using Microsoft.AspNetCore.Http;

namespace Mc2.CrudTest.Endpoints.WebApi.Controllers.Customers.Models
{
    public class ApiResult<TData>
    {
        public TData Data { get; }

        public ApiResult(TData data)
        {
            Data = data;
        }
    }
}
