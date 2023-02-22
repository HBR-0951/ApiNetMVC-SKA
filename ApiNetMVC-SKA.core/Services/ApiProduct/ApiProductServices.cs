using System.Text.Json;
using ApiNetMVC_SKA.core.Repositories.ApiProductRepo;

namespace ApiNetMVC_SKA.core.Services.ApiProduct;

public interface IApiProductServices
{
    public ApiProduct DefaultApiProduct();

}

public class ApiProductServices : IApiProductServices
{
    public ApiProduct DefaultApiProduct()
    {
        var apiProduct = new ApiProduct()
        {
            Id = 0,
            Amount = 0,
            Date = DateTime.Now,
            Remark = "Remark!"
        };
        return apiProduct;
    }

}