using System.Diagnostics;
using System.Text.Json;
using ApiNetMVC_SKA.core.Repositories.ApiProductRepo;
using ApiNetMVC_SKA.core.Services.ApiProduct;
using Microsoft.AspNetCore.Mvc;
using ApiNetMVC_SKA.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiNetMVC_SKA.Controllers;

public class ApiProductController : Controller
{
    private readonly ILogger<ApiProductController> _logger;
    private readonly IApiProductServices _apiProductServices;
    private readonly IApiProductRepo _apiProductsRepo;

    public ApiProductController(ILogger<ApiProductController> logger, IApiProductServices apiProductServices, IApiProductRepo apiProductsRepo)
    {
        _logger = logger;
        _apiProductServices = apiProductServices;
        _apiProductsRepo = apiProductsRepo;
    }

    public IActionResult Index()
    {
        return View(OnInitializedPage());
    }

    private Product OnInitializedPage()
    {
        var defaultProduct = DefaultProduct();
        GetProductsList(defaultProduct);
        return defaultProduct;
    }


    public IActionResult Save(Product product)
    {
        return RedirectToAction("ProductsPage", product);
    }

    public IActionResult ProductsPage(Product product)
    {
        if (!AmountIsPositiveInteger(product))
        {
            AddAmountErrorMsg("Amount need > 0");
        } 
        if (ModelState.IsValid)
        {
            InsertToApiProductsRepo(product);
        }

        return View("Index", GetProductsDetail(product));
    }

    [Route("/api/records")]
    public IActionResult ShowJsonFile(Product product)
    {
        product.ProductsListJsonFile = _apiProductsRepo.CallApiProductsListJson();
        return View("JsonFile", product);
    }

    private void AddAmountErrorMsg(String msg)
    {
        ModelState.AddModelError("Amount", msg);
    }

    private static bool AmountIsPositiveInteger(Product product)
    {
        return product.Amount > 0;
    }


    private Product GetProductsDetail(Product product)
    {
        GetProductsList(product);
        ProductValueChangeToDefault(product);
        return product;
    }
    private void InsertToApiProductsRepo(Product product)
    {
        var apiProduct = ProductToApiProduct(product);
        _apiProductsRepo.InsertApiProduct(apiProduct);
    }

    private void GetProductsList(Product product)
    {
        product.ProductsList = ApiProductsListToProductList();
    }

    private List<Product> ApiProductsListToProductList()
    {
        var productsList = new List<Product>();
        foreach (var apiProduct in _apiProductsRepo.GetApiProductsList())
        {
            var product = ApiProductToProduct(apiProduct);
            productsList.Add(product);
        }
        return productsList;
    }

    private void ProductValueChangeToDefault(Product product)
    {
        ChangeProductValue(product, amount: 0, date: DateTime.Now, remark: "Remark!");
    }
    private Product DefaultProduct()
    {
        var defaultApiProduct = _apiProductServices.DefaultApiProduct();
        var defaultProduct = ApiProductToProduct(defaultApiProduct);
        return defaultProduct;
    }
    private void ChangeProductValue(Product product, int amount, DateTime date, String remark)
    {
        product.Amount = amount;
        product.Date = date;
        product.Remark = remark;
        
    }

    private Product ApiProductToProduct(ApiProduct apiProduct)
    {
        Product product = new Product();
        product.Id = apiProduct.Id;
        product.Amount = apiProduct.Amount;
        product.Date = apiProduct.Date;
        product.Remark = apiProduct.Remark;
        
        return product;
    }
    private ApiProduct ProductToApiProduct(Product product)
    {
        ApiProduct apiProduct = new ApiProduct();
        apiProduct.Id = product.Id;
        apiProduct.Amount = product.Amount;
        apiProduct.Date = product.Date;
        apiProduct.Remark = product.Remark;
        return apiProduct;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}