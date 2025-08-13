using CommonCore.MongoDB;
using MongoDB.Driver;

public class EntityMongoDBHandler<T> where T : BasicModel
{
    private readonly IMongoCollection<T> _EntitysCollection;
    private readonly string _connectionString = "mongodb+srv://admin:admin@cluster0.udbu4nw.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

    public EntityMongoDBHandler(bool isAtlas, string databaseName, string collectionName)
    {
        var connectionString = isAtlas ? _connectionString : "mongodb://localhost:27017";
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _EntitysCollection = database.GetCollection<T>(collectionName);
    }

    public EntityMongoDBHandler(string connectionString, string databaseName, string collectionName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _EntitysCollection = database.GetCollection<T>(collectionName);
    }

    public async Task InsertEntityAsync(T t)
    {
        t.CreatedBy ??= "System";
        t.CreateTime = DateTime.Now;
        await _EntitysCollection.InsertOneAsync(t);
    }

    public async Task<List<T>> GetAllEntitiesAsync()
    {
        return await _EntitysCollection.Find(_ => true).ToListAsync();
    }

    public async Task<T> GetUserEntityByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(u => u.Id, id);
        return await _EntitysCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateEntityAsync(T t)
    {
        t.UpdatedBy ??= "System";
        t.UpdateTime = DateTime.Now;
        var filter = Builders<T>.Filter.Eq(u => u.Id, t.Id);
        await _EntitysCollection.ReplaceOneAsync(filter, t);
    }

    public async Task DeleteEntityAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(u => u.Id, id);
        await _EntitysCollection.DeleteOneAsync(filter);
    }
}