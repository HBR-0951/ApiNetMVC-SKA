using System.ComponentModel.DataAnnotations;

namespace ApiNetMVC_SKA.core.Services.ApiProduct;

public class ApiProduct
{
    public int Id { get; set; }
    [Required(ErrorMessage = "cant be null")]
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = "can not be null")]
    public string? Remark { get; set; }
}