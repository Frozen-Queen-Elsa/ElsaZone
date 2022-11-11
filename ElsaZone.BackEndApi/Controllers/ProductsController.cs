using ElsaZone.Application.Catalog.Products;
using ElsaZone.ViewModels.Catalog.ProductImage;
using ElsaZone.ViewModels.Catalog.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElsaZone.BackEndApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    
    // GET
    private readonly IPublicProductService _publicproductService;

    public ProductsController(IPublicProductService publicproductService)
    {
        _publicproductService = publicproductService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var products = await _publicproductService.GetAll();
        return Ok("That is ok");
    }
    
}