using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LifeManagementApp.Data;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services;

public class NoteRepository : INoteRepository
{
    private readonly AppDbContext _db;

    public NoteRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Note?> GetNoteAsync()
    {
        return await _db.Notes.FirstOrDefaultAsync();
    }

    public async Task SaveNoteAsync(string content)
    {
        var note = await _db.Notes.FirstOrDefaultAsync();

        if (note == null)
        {
            note = new Note
            {
                Content = content
            };

            _db.Notes.Add(note);
        }
        else
        {
            note.Content = content;
        }

        await _db.SaveChangesAsync();
    }
}