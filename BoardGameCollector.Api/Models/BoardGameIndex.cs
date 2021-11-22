namespace BoardGameCollector.Api.Models;

public class BoardGameIndex {
    public BoardGameIndex(int id, string name, string type)
    {
        this.Id = id;
        this.Name = name;
        this.Type = type;
    }
    public string Name {get;set;}
    public int Id {get;set;}
    public string Type { get; set; }
}