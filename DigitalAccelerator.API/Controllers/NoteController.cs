using DigitalAccelerator.API.Dto;
using DigitalAccelerator.API.Entities;
using DigitalAccelerator.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;

namespace DigitalAccelerator.API.Controllers
{
    [Authorize] // comment out to make changes without needing a token
    [ApiController]
    [Route("api/note")]
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepository;
        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository ??
                throw new ArgumentNullException(nameof(noteRepository));
        }

        //GET ALL NOTES

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetAllNotes()
        {
            var notes = await _noteRepository.GetAllNotesAsync();
            return Ok(notes);
        }

        //GET NOTE BY ID -- right now does not display related notes if includeRelatedNotes == true
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNoteById(int noteId)
        {
            var note = await _noteRepository.GetNoteAsync(noteId);                                                                                        
            return Ok(note);
        }

        //ADD A NEW NOTE
        [HttpPost("")]
        public async Task<ActionResult<Note>> AddNewNote([FromBody] NoteDto newNote)
        {
            var id = await _noteRepository.AddNoteAsync(newNote.Author, newNote.Content);
            return CreatedAtAction(nameof(GetNoteById), new { Id = id, controller = "note" }, id);
        }

        //DELETE A NOTE
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int noteId)
        {
            await _noteRepository.DeleteNoteAsync(noteId);
            return Ok();
        }

        //UPDATE ALL PROPERTIES OF A NOTE
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNote([FromRoute] int id, string updatedAuthor, string updatedContent)
        {
            await _noteRepository.UpdateNoteAsync(id, updatedAuthor, updatedContent);
            return Ok();
        }

        //UPDATE SPECIFIC PROPERTIES OF A NOTE
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateNotePatch([FromRoute] int id, [FromBody] JsonPatchDocument noteModel)
        {
            await _noteRepository.UpdateNotePatchAsync(id, noteModel);
            return Ok();
        }
    }       
}
