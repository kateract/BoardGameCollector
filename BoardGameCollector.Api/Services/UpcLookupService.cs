using BoardGameCollector.Api.Models;
using UPCItemDb;

namespace BoardGameCollector.Api.Services;

public interface IUpcLookupService
{
    Task<IEnumerable<Product>> GetProductsAsync(string upcCode);
}

public class UpcLookupService : IUpcLookupService
{
    private readonly UPCItemDBClient client;

    public UpcLookupService(UPCItemDBClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(string upcCode)
    {
        try
        {
            var items = await client.LookupByGetAsync(upcCode);
            var products = items.Items.Select(i =>
            {
                return new Product()
                {
                    Images = i.Images,
                    Brand = i.Brand,
                    Description = i.Description,
                    ASIN = i.ASIN,
                    GTIN = i.GTIN,
                    UPC = i.UPC,
                    Title = i.Title,
                    EAN = i.EAN,
                    Model = i.Model
                };
            });

            return products;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (client.ErrorResponse is not null)
        {
            Console.WriteLine(client.ErrorResponse.Message);
        }
        return new List<Product>();
    }
}