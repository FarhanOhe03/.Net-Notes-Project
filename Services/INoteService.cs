using NotesApp.Models;

namespace NotesApp.Services
{
    public interface INoteService
    {
        Task<List<Note>> GetAllNotesAsyn();
        Task<Note?> GetNoteNyIdAsync(int id);
        Task CreateNoteAsync(Note note);
        Task UpdateNoteAsync(Note note);
        Task DeleteNoteAsync(int id);

    }
}