using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NoteAPI.Domain.Entities.Models;

namespace NoteAPI.Repositories
{
    public class NoteDatabaseContext
    {
        private readonly IMongoCollection<Notes> _noteCollection;

        public NoteDatabaseContext(
            IOptions<NoteDatabaseSettings> noteDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                noteDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                noteDatabaseSettings.Value.DatabaseName);

            _noteCollection = mongoDatabase.GetCollection<Notes>(
                noteDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Notes>> GetAsync() =>
            await _noteCollection.Find(x => true).ToListAsync();

        public async Task<Notes?> GetAsync(string id) =>
            await _noteCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Notes note) =>
            await _noteCollection.InsertOneAsync(note);

        public async Task UpdateAsync(string id, Notes note) =>
            await _noteCollection.ReplaceOneAsync(x => x.Id == id, note);

        public async Task RemoveAsync(string id) =>
            await _noteCollection.DeleteOneAsync(x => x.Id == id);
    }
}
