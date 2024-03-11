using Play.Inventory.Service.DTOs;

namespace Play.Inventory.Service.Client
{
    public class CatalogClient
    {
        private readonly HttpClient httpClient;

        //Dependency Injection
        public CatalogClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<CatalogItemDto>> GetCatalogItemsAsync()
        {
            var items = await httpClient.GetFromJsonAsync<IReadOnlyCollection<CatalogItemDto>>("/items");
            return items;
        }
    }
}