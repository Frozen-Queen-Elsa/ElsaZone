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
    private readonly IProductService _productService;
    
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    //http://localhost:port/products
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var products = await _productService.GetAll();
        return Ok("That is ok");
    }
    
    //http://localhost:port/products/public-paging
    [HttpGet("public-paging")]
    public async Task<ActionResult> Get([FromQuery]GetPublicProductPagingRequest request)
    {
        var products = await _productService.GetAllByCategoryId(request);
        return Ok("That is ok");
    }
    //http://localhost:port/products/ProductId
    [HttpGet("{ProductId}")]
    public async Task<ActionResult> GetById(int ProductId)
    {
        var products = await _productService.GetById(ProductId);
        if (products == null)
            return BadRequest("Cannot find product");
        return Ok("That is ok");
    }
    
    [HttpPost]
    [Consumes("multipart/form-data")]
    [Authorize]
    public async Task<ActionResult> Create([FromBody]ProductCreateRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var productId = await _productService.Create(request);
        if (productId == 0)
            return BadRequest();

        var product = await _productService.GetById(productId);

        return CreatedAtAction(nameof(GetById), new { id = productId }, product);
    }
    
    [HttpPut]
    public async Task<ActionResult> Update([FromBody]ProductUpdateRequest request)
    {
     
        var affectedResult = await _productService.Update(request);
        if (affectedResult == 0)
            return BadRequest();

        return Ok();
    }
    [HttpPatch("{ProductId}/IsDeleted")]
    public async Task<IActionResult> UpdateIsDeleted(int ProductId)
    {
     
        var isSuccessful = await _productService.UpdateIsDeletedProduct(ProductId);
        if (isSuccessful)
            return Ok();

        return BadRequest();
    }

    [HttpPatch("{ProductId}/ViewCount")]
    public async Task<IActionResult> AddViewCount(int ProductId)
    {
     
        var isSuccessful = await _productService.AddViewCount(ProductId);
        if (isSuccessful)
            return Ok();

        return BadRequest();
    }
}