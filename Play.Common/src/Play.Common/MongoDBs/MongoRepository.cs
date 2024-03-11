using MongoDB.Driver;
using System.Linq.Expressions;

namespace Play.Common.MongoDBs
{
    public class MongoRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> dbCollection;

        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            //var mongoClient = new MongoClient("mongodb://localhost:27017/");
            //var database = mongoClient.GetDatabase("Catalog");
            //I have moved the logic of defining and using the NoSQL DB in appsettings.json, check it out. also check Program.cs
            dbCollection = database.GetCollection<T>(collectionName);
        }

        //không cần filter, vì... chỉ cần lấy về tất cả item trong khi load
        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        //không cần filter, vì... chỉ cần lấy về tất cả item trong khi load
        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await dbCollection.Find(filter).ToListAsync();
        }

        //không cần filter, vì... chỉ cần lấy về tất cả item trong khi load
        public async Task<T> GetAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        //không cần filter, vì... chỉ cần lấy về tất cả item trong khi load
        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            //create an item into the database
            await dbCollection.InsertOneAsync(entity);
        }

        public async Task updateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<T> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task removeAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}