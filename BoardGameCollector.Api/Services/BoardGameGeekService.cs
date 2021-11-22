using BoardGameCollector.Api.Models;
using BoardGamer.BoardGameGeek.BoardGameGeekXmlApi2;

namespace BoardGameCollector.Api.Services;

public interface IGameInformationService {
    Task<BoardGame?> GetBoardGameAsync(Product product, int geekId);
    Task<IEnumerable<BoardGameIndex>> GetBoardGameByNameAsync(Product product);    
}

public class BoardGameGeekService: IGameInformationService
{
    private readonly BoardGameGeekXmlApi2Client client;

    public BoardGameGeekService(BoardGameGeekXmlApi2Client client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<BoardGameIndex>> GetBoardGameByNameAsync(Product product)
    {
        var result = await client.SearchAsync(new SearchRequest(product.Title));
        if (result.Succeeded)
        {
            var games = result.Result.Items.Select(i =>
            {
                return new BoardGameIndex(i.Id, i.Name, i.Type);
            });
            return games;
        }
        return new List<BoardGameIndex>();
    }

    public async Task<BoardGame?> GetBoardGameAsync(Product product, int geekId)
    {
        ThingResponse.Item result = await client.GetBoardGameAsync(geekId);
        if (result is null)
        {
            return null;
        }
        var game = new BoardGame()
        {
            BoardGameGeekId = result.Id,
            Name = result.Name,
            ReleaseDate = result.ReleaseDate,
            MinAge = result.MinAge,
            MaxPlayingTime = result.MaxPlayingTime,
            PlayingTime = result.PlayingTime,
            MinPlayers = result.MinPlayers,
            MaxPlayers = result.MaxPlayers,
            YearPublished = result.YearPublished,
            AlternateNames = result.AlternateNames,
            Image = result.Image,
            Thumbnail = result.Thumbnail,
            Type = result.Type
        };
        return game;

    }
}