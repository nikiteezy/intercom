using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Intercom.Data;

public class DataService
{
    private readonly IMongoCollection<Models.Intercom> _usersCollection;

    public DataService(
        IOptions<DataStoreDatabaseSettings> dataStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            dataStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            dataStoreDatabaseSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<Models.Intercom>(
            dataStoreDatabaseSettings.Value.IntercomCollectionName);
    }

    public async Task<List<Models.Intercom>> GetAsync() =>
        await _usersCollection.Find(_ => true).ToListAsync();

    public async Task<Models.Intercom?> GetAsync(string id) =>
        await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Models.Intercom newBook) =>
        await _usersCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Models.Intercom updatedBook) =>
        await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x.Id == id);
}
