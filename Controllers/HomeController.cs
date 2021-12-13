using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PalindromeSagasMVC.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PalindromeSagasMVC.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Palindrome()
        {
            Palindrome model = new();
            return View(model);
                   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Palindrome(Palindrome palindrome)
        {
            string inputWord = palindrome.InputWord;
            string revWord = "";
            for (int i = inputWord!.Length - 1; i >= 0; i--)
            {
                revWord += inputWord[i];
            }

            palindrome.RevWord = revWord;

            revWord = Regex.Replace(revWord.ToLower(), "[^a-zA-Z0-9]+", "");
            inputWord = Regex.Replace(inputWord.ToLower(), "[^a-zA-Z0-9]+", "");

            if(revWord == inputWord)
            {
                palindrome.IsPalindrome = true;
                palindrome.Message = $"Success {palindrome.InputWord} is a Palindrome";
            } 
            else
            {
                palindrome.IsPalindrome = false;
                palindrome.Message = $"Sorry {palindrome.InputWord} is not a Palindrome";
            }
            return View(palindrome);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}