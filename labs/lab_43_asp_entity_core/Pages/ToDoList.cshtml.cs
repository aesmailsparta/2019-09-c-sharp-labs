using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_43_asp_entity_core.Pages.Shared
{
    public class ToDoListModel : PageModel
    {
        public List<ToDoItem> MyItems { get; set; } = new List<ToDoItem>();

        public void OnGet()
        {
            using(var db = new ToDoItemContext())
            {
                MyItems = db.ToDoItems.ToList();
            }
        }
    }
}