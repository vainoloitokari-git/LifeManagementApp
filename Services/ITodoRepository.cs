using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAllAsync();

        Task AddAsync(TodoItem item);

        Task<List<TodoItem>> GetTopThreeAsync();
    }
}
