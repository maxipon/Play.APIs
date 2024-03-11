namespace Play.Inventory.Service.DTOs
{
    //initially this is only ItemDto, but since this method is calling from Play.Catalog, I'm putting this way to avoid ambigious
    //and to avoid conflict with the original one from Catalog ^.^
    public record CatalogItemDto(Guid id, string Name, string Description);

    public record GrantItemsDto(Guid UserId, Guid CatalogItemId, int Quantity);

    public record InventoryItemDto(Guid CatalogItemId, string Name, string Description, int Quantity, DateTimeOffset AcquiredDate);
}