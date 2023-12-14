using Microsoft.AspNetCore.Mvc;
using NoteAPI.Domain.Entities.Dtos;
using NoteAPI.Domain.Entities.Models;
using NoteAPI.Exceptions;
using NoteAPI.Services;

namespace NoteAPI.Controllers
{
    [ApiController]
    [Route("Note")]
    public class NoteController : Controller
    {
        private NoteServices _noteService { get; set; }
        public NoteController(NoteServices noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("notes")]
        public async Task<IActionResult> GetNotes()
        {
            try
            {
                List<Notes> notes = await _noteService.GetNotes();

                if (notes.Count == 0)
                    return NoContent();

                return Ok(notes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetNoteById([FromQuery] string id)
        {
            try
            {
                Notes note = await _noteService.GetNoteById(id);

                return Ok(note);
            }
            catch (EmptyIdException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNote([FromBody] NoteDto note)
        {
            try
            {

                await _noteService.CreateNote(note);

                return Ok("Note created!");
            }
            catch (EmptyNoteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateNote([FromBody] NoteDto note)
        {
            try
            {
                await _noteService.UpdateNote(note);

                return Ok("Note updated!");
            }
            catch (EmptyIdException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (EmptyNoteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteNote([FromQuery] string id)
        {
            try
            {
                await _noteService.DeleteNote(id);

                return Ok("Note deleted!");
            }
            catch (EmptyIdException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/all")]
        public async Task<IActionResult> DeleteAllNotes()
        {
            try
            {
                List<Notes> notes = await _noteService.GetNotes();

                await _noteService.DeleteAllNotes(notes);

                return Ok("All notes deleted!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
