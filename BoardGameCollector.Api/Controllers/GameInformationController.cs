using BoardGameCollector.Api.Models;
using BoardGameCollector.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameCollector.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GameInformationController: ControllerBase {
    private readonly ILogger<GameInformationController> logger;
    private readonly IGameInformationService gameInfoSvc;

    public GameInformationController(ILogger<GameInformationController> logger, IGameInformationService gameInfoSvc)
    {
        this.logger = logger;
        this.gameInfoSvc = gameInfoSvc;
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchGames([FromBody]Product product) {
        var info = await gameInfoSvc.GetBoardGameByNameAsync(product);
        return Ok(info);
    }
}