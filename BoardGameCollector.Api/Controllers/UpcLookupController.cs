using BoardGameCollector.Api.Models;
using BoardGameCollector.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameCollector.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UpcLookupController : ControllerBase {
    private readonly ILogger<UpcLookupController> logger;
    private readonly IUpcLookupService upcService;

    public UpcLookupController(ILogger<UpcLookupController> logger, IUpcLookupService upcService)
    {
        this.logger = logger;
        this.upcService = upcService;
    }

    [HttpGet("{upcCode}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string upcCode) {
        var products = await upcService.GetProductsAsync(upcCode);
        if(!products.Any()) {
            return NotFound();
        }
        return Ok(products);
    }
}