using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class AllRecords
    {
        public AllRecords()
        {
            Todos = new List<Todo>();
            Histories = new List<History>();
        }

        public List<Todo> Todos { get; set; }

        public List<History> Histories { get; set; }
    }
}