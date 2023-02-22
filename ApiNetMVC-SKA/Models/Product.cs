using System.ComponentModel.DataAnnotations;

namespace ApiNetMVC_SKA.Models;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "cant be null")]
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = "can not be null")]
    public string? Remark { get; set; }

    private  List<Product>? _productsList;
    public  List<Product>? ProductsList
    {
        get { return _productsList;}
        set { _productsList = value; }
    }
    
    public string? ProductsListJsonFile { get; set; }

}