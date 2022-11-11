using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ElsaZone.ViewModels.Catalog.Product;

public class ProductCreateRequest
{

    public int CategoryId { set; get; }
    [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
    public string ProductName { set; get; }
    [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
    public int Quantity { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal Discount { set; get; }
    public decimal SellPrice { set; get; }

    public string SEOTitle { set; get; }
    public string SEODescription { set; get; }
    public string SEOAlias { set; get; }

    public IFormFile DefaultImage { get; set; }

}