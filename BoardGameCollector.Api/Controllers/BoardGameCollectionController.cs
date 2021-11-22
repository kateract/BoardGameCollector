using BoardGameCollector.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameCollector.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardGameCollectionController : ControllerBase
{


    private readonly ILogger<BoardGameCollectionController> logger;

    public BoardGameCollectionController(ILogger<BoardGameCollectionController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public IEnumerable<BoardGameCollection> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new BoardGameCollection())
        .ToArray();
    }
}
