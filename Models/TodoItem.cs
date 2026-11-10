using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LifeManagementApp.Models;

public class TodoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public int Priority { get; set; }

    public DateTime DueDate { get; set; }

    public bool IsDone { get; set; }

    public string PriorityText => Priority switch
    {
        1 => "🔴 Erittäin tärkeä",
        2 => "🟡 Ei kiireellinen",
        3 => "🟢 Voi suorittaa myöhemmin",
        _ => "⚪ Tuntematon"
    };
}
