using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class FactorialModel : PageModel
    {
        public int Number { get; set; }
        public int Result { set; get; }
        public bool IsCorrect { set; get; } = true;
        public string Message { set; get; }
        public void OnGet(int? number)
        {
            if (number == null || number < 1)
            {
                IsCorrect = false;
                return;
            }
            Number = number.Value;
            Result = 1;
            for(int i = 1;i<=number;i++)
            {
                Result *= i;
            }
            Message = $"Факториал числа {Number} равен {Result} get";
        }

        public void OnPost(int? number)
        {
            if (number == null || number < 1)
            {
                IsCorrect = false;
                return;
            }
            Number = number.Value;
            Result = 1;
            for (int i = 1; i <= number; i++)
            {
                Result *= i;
            }
            Message = $"Факториал числа {Number} равен {Result} post";
        }

    }
}