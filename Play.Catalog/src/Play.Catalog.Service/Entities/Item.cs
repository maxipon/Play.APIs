//I have packed the Play.Common using "dotnet pack" command
//then I have added it as an library here
// using "dotnet nuget add source (your directory) -n (your name, this is an example)PlayEconomy"
using Play.Common;

namespace Play.Catalog.Services.Entities
{
    public class Item : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}