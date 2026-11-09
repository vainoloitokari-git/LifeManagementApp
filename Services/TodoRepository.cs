using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LifeManagementApp.Data;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services
{
    public class TodoRepository : ITodoRepository

    {
    private readonly AppDbContext _db;

    public TodoRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        return await _db.Todos.ToListAsync();
    }

    public async Task AddAsync(TodoItem item)
    {
        _db.Todos.Add(item);

        await _db.SaveChangesAsync();

    }
}
