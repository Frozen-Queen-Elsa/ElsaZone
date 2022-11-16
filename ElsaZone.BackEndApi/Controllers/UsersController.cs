using Microsoft.AspNetCore.Mvc;

namespace ElsaZone.BackEndApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
}