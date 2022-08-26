using DigitalAccelerator.API.DbContexts;
using DigitalAccelerator.API.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccelerator.API.Services
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteContext _context;
        public NoteRepository(NoteContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //GET NOTES AND RELATED NOTES
        public async Task<Note?> GetNoteAsync(int noteId)
        {
            return await _context.Notes.Where(n => n.Id == noteId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return await _context.Notes.OrderBy(c => c.Author).ToListAsync();
        }


        //ADD NOTES
        public async Task<int?> AddNoteAsync(string author, string content)
        {
            var newNote = new Note(author, content);
            _context.Notes.Add(newNote);
            await _context.SaveChangesAsync();
            return newNote.Id;
        }

        //DELETE NOTES
        public async Task DeleteNoteAsync(int noteId)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == noteId);
            if(note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }

        //UPDATE AND EDIT NOTES
        public async Task UpdateNoteAsync(int noteId, string updatedAuthor, string updatedContent)
        {
            var note = await _context.Notes.FindAsync(noteId);
            if(note != null)
            {
                note.Author = updatedAuthor;
                note.Content = updatedContent;
                //call method(in note entity) to update author and content

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateNotePatchAsync(int noteId, JsonPatchDocument noteModel)
        {
            var note = await _context.Notes.FindAsync(noteId);
            if (note != null)
            {
                noteModel.ApplyTo(note);
                await _context.SaveChangesAsync();
            }
        }

    }
}
