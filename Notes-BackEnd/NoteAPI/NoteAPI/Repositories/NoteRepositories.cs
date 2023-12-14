using NoteAPI.Domain.Entities.Models;

namespace NoteAPI.Repositories
{
    public class NoteRepositories
    {
        private NoteDatabaseContext _databaseRespositories { get; set; }
        public NoteRepositories(NoteDatabaseContext databaseRepositories)
        {
            _databaseRespositories = databaseRepositories;
        }

        public async Task<List<Notes>> ListNotes()
        {
            return await _databaseRespositories.GetAsync();
        }

        public async Task<Notes> GetNote(string id)
        {
            return await _databaseRespositories.GetAsync(id);
        }

        public async Task CreateNote(Notes note)
        {
            await _databaseRespositories.CreateAsync(note);
        }

        public async Task UpdateNote(string id, Notes note)
        {
            await _databaseRespositories.UpdateAsync(id, note);
        }

        public async Task DeleteNote(string id)
        {
            await _databaseRespositories.RemoveAsync(id);
        }
    }
}
