using NoteAPI.Domain.Entities.Dtos;
using NoteAPI.Domain.Entities.Models;
using NoteAPI.Exceptions;
using NoteAPI.Repositories;

namespace NoteAPI.Services
{
    public class NoteServices
    {
        private NoteRepositories _noteRepositories { get; set; }
        public NoteServices(NoteRepositories noteRepositories)
        {
            _noteRepositories = noteRepositories;
        }

        public async Task<List<Notes>> GetNotes()
        {
            try
            {
                List<Notes> notes = await _noteRepositories.ListNotes();

                return notes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Notes> GetNoteById(string id)
        {
            try
            {
                return await _noteRepositories.GetNote(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreateNote(NoteDto note)
        {
            try
            {
                if (!note.isValid())
                {
                    Notes notes = new Notes();

                    notes.ConvertNoteDtoToNote(note);

                    await _noteRepositories.CreateNote(notes);
                }
                else
                {
                    throw new EmptyNoteException("Note can not be empty!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateNote(NoteDto note)
        {
            try
            {
                if (!note.isValid())
                {
                    Notes notes = new Notes();

                    notes.ConvertNoteDtoToNote(note);

                    if (!notes.isValid())
                    {
                        if (string.IsNullOrWhiteSpace(notes.Id))
                            throw new EmptyIdException("Id can not be empty!");
                        if (string.IsNullOrWhiteSpace(notes.Note))
                            throw new EmptyNoteException("Note can not be empty!");
                    }

                    await _noteRepositories.UpdateNote(notes.Id, notes);
                }
                else
                {
                    throw new EmptyNoteException("Note can not be empty!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteNote(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    await _noteRepositories.DeleteNote(id);
                }
                else
                {
                    throw new EmptyIdException("Id can not be empty!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAllNotes(List<Notes> notes)
        {
            try
            {
                foreach (var note in notes)
                {
                    await _noteRepositories.DeleteNote(note.Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
