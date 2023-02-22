

using ApiNetMVC_SKA.core.Services.ApiProduct;
using System.Text.Json;

namespace ApiNetMVC_SKA.core.Repositories.ApiProductRepo;

public interface IApiProductRepo
{
    List<ApiProduct> GetApiProductsList();
    void InsertApiProduct(ApiProduct apiProduct);
    string CallApiProductsListJson();
}

public class ApiProductRepo : IApiProductRepo
{
    private static List<ApiProduct> _apiProductsList = new List<ApiProduct>();

    public void InsertApiProduct(ApiProduct apiProduct)
    {
        apiProduct.Id = _apiProductsList.Count + 1;
        _apiProductsList.Add(apiProduct);
    }

    public List<ApiProduct> GetApiProductsList()
    {
        return _apiProductsList;
    }

    public string CallApiProductsListJson()
    {
        return JsonSerializer.Serialize(_apiProductsList);
    }

    
}