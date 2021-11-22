namespace BoardGameCollector.Api.Models;

public class Product {

        public string[] Images { get; set; } = {};
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public string? ASIN { get; set; }
        public string? GTIN { get; set; }
        public string? UPC { get; set; }
        public string? Title { get; set; }
        public string? EAN { get; set; }
        public string? Model { get; set; }
}