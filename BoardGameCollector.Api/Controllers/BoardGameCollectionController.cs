using BoardGameCollector.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameCollector.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardGameCollectionController : ControllerBase
{


    private readonly ILogger<BoardGameCollectionController> _logger;

    public BoardGameCollectionController(ILogger<BoardGameCollectionController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<BoardGameCollection> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new BoardGameCollection())
        .ToArray();
    }
}
