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
        return Ok(products);
    }
    
    //http://localhost:port/products/paging
    [HttpGet("paging")]

    public async Task<ActionResult> Get([FromQuery]GetManageProductPagingRequest request)
    {
        var products = await _productService.GetAllPaging(request);
        return Ok(products);
    }
    
    //http://localhost:port/products/public-paging
    [HttpGet("public-paging")]

    public async Task<ActionResult> Get([FromQuery]GetPublicProductPagingRequest request)
    {
        var products = await _productService.GetAllByCategoryId(request);
        return Ok(products);
    }
    //http://localhost:port/products/(ProductId)
    [HttpGet("{ProductId}")]
   
    public async Task<ActionResult> GetById(int ProductId)
    {
        var product = await _productService.GetById(ProductId);
        if (product == null)
            return BadRequest("Cannot find product");
        return Ok(product);
    }
    
    [HttpPost]
    [Consumes("multipart/form-data")]

    public async Task<ActionResult> Create([FromForm]ProductCreateRequest request)
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
    
    [HttpPut("{ProductId}")]
    
    public async Task<ActionResult> Update([FromRoute]int ProductId,ProductUpdateRequest request)
    {
     
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        request.ProductId = ProductId;
        var affectedResult = await _productService.Update(request);
        if (affectedResult == 0)
            return BadRequest();
        return Ok("Update thành công product ");
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
    
    [HttpPatch("{ProductId}/{newSellPrice}")]
 
    public async Task<IActionResult> UpdateSellPrice(int ProductId, decimal newSellPrice)
    {
        var isSuccessful = await _productService.UpdateSellPrice(ProductId, newSellPrice);
        if (isSuccessful)
            return Ok();
        return BadRequest();
    }

    [HttpPatch("{ProductId}/{newDiscount}")]

    public async Task<IActionResult> UpdateDiscount(int ProductId, decimal newDiscount)
    {
        var isSuccessful = await _productService.UpdateDiscount(ProductId, newDiscount);
        if (isSuccessful)
            return Ok();
        return BadRequest();

    }

    [HttpPatch("{ProductId}/{newQuantity}")]

    public async Task<IActionResult> UpdateQuantity(int ProductId, int newQuantity)
    {
        var isSuccessful = await _productService.UpdateQuantity(ProductId, newQuantity);
        if (isSuccessful)
            return Ok();
        return BadRequest();
    }
    
    //http://localhost:port/products/{ProductId}/listimages/
    [HttpGet("/{ProductId}/listimages")]
    public async Task<IActionResult> GetListImag(int ProductId)
    {
        var images = await _productService.GetListImages(ProductId);
        if (images == null)
            return BadRequest("Cannot find images");
        return Ok(images);
    }
    
    
    //http://localhost:port/products/images/{ProductImageId}
    [HttpGet("/images/{ProductImageId}")]
    public async Task<IActionResult> GetImageById(int ProductImageId)
    {
        var image = await _productService.GetImageById(ProductImageId);
        if (image == null)
            return BadRequest("Cannot find image");
        return Ok(image);
    }
    
    //Images
    [HttpPost("{ProductId}/createimages")]
    public async Task<IActionResult> CreateImage(int ProductId, [FromForm] ProductImageCreateRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var imageId = await _productService.AddImage(ProductId, request);
        if (imageId == 0)
            return BadRequest();

        var image = await _productService.GetImageById(imageId);

        return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
    }
    
    
    [HttpDelete("images/{ProductImageId}/remove")]
    [Authorize]
    public async Task<IActionResult> RemoveImage(int ProductImageId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _productService.RemoveImage(ProductImageId);
        if (result == 0)
            return BadRequest();

        return Ok();
    }
    
    [HttpPut("images/{ProductImageId}")]
    [Authorize]
    public async Task<IActionResult> UpdateImage(int ProductImageId, [FromForm] ProductImageUpdateRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _productService.UpdateImage(ProductImageId, request);
        if (result == 0)
            return BadRequest();

        return Ok();
    }
}