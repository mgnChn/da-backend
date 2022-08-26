using DigitalAccelerator.API.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace DigitalAccelerator.API.Services
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAllNotesAsync();
        Task<Note?> GetNoteAsync(int noteId);
        Task<int?> AddNoteAsync(string author, string content);
        Task DeleteNoteAsync(int noteId);
        Task UpdateNoteAsync(int noteId, string updatedAuthor, string updatedContent);
        Task UpdateNotePatchAsync(int noteId, JsonPatchDocument noteModel);
    }
}
