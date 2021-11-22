namespace BoardGameCollector.Api.Models;

public class BoardGame : Product
{
    public BoardGame()
    {
        AlternateNames = new List<string>();
    }
    public int BoardGameGeekId { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? MinAge { get; set; }
    public int? MaxPlayingTime { get; set; }
    public int? MinPlayingTime { get; set; }
    public int? PlayingTime { get; set; }
    public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; }
    public int? YearPublished { get; set; }
    public List<string> AlternateNames { get; set; }
    public string Name { get; set; } = "";
    public string Image { get; set; } = "";
    public string Thumbnail { get; set; } = "";
    public string Type { get; set; } = "";
    public int Id { get; set; }

}