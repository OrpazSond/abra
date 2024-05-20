using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using server_side.Models;
using Microsoft.Extensions.Hosting;

namespace server_side.Services
{
    public class PetService
    {
        private readonly IMongoCollection<Pet> _petCollection;

        public PetService(IOptions<MongoDBSettings> settings)
        {
            MongoClient mongoClient = new MongoClient(settings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _petCollection = mongoDatabase.GetCollection<Pet>("Pets");
        }

        public async Task AddPet(Pet pet)
        {
            await _petCollection.InsertOneAsync(pet);
            return;
        }

        public async Task<List<Pet>> GetAll()
        {
            return await _petCollection.Find(new BsonDocument()).ToListAsync();          
        }


    }
}
