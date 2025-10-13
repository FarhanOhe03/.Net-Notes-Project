using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Services
{
    public class NoteService : INoteService
    {
        private readonly NotesDbContext _context;

        public NoteService(NotesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _context.Notes
                .OrderByDescending(n => n.CreatedDate)
                .ToListAsync();
        }

        public async Task<Note?> GetNoteByIdAsync(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task CreateNoteAsync(Note note)
        {
            note.CreatedDate = DateTime.Now;
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

       public async Task UpdateNoteAsync(Note note)
{
    // Find the existing tracked entity
    var existingNote = await _context.Notes.FindAsync(note.Id);
    
    if (existingNote != null)
    {
        // Update the properties of the tracked entity
        existingNote.Title = note.Title;
        existingNote.Content = note.Content;
        existingNote.Priority = note.Priority;
        existingNote.LastModifiedDate = DateTime.Now;
        
        // No need to call Update() - the entity is already tracked
        await _context.SaveChangesAsync();
    }
}

        public async Task DeleteNoteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<Note>> GetAllNotesAsyn()
        {
            throw new NotImplementedException();
        }

        public Task<Note?> GetNoteNyIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}