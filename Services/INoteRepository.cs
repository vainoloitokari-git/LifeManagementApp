using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services;

public interface INoteRepository
{
    Task<Note?> GetNoteAsync();

    Task SaveNoteAsync(string content);
}