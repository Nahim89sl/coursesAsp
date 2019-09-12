using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class PersonModel : PageModel
    {
        public string Message { set; get; }

        [BindProperty(Name ="name")]
        public string Name { get; set; }

        [BindProperty(Name="surname")]
        public string Surname { get; set; }

        public void OnGet()
        {
            Message = "Enter your data";
         

        }

        public void OnPost()
        {
            Message = $"Вы зарегистрированы как {Name} {Surname}";
        }
    }
}