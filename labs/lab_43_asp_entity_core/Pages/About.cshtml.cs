using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_43_asp_entity_core.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public List<string> myItems { get; set; } = new List<string>()
        {
            "one", "two", "three"
        };

        public void OnGet()
        {
            Message = "Your application description page.";
        }
    }
}
