using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicTaskOne.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTaskOne.Controllers
{
    public class HomeController : Controller
    {
        public List<Song> list = new List<Song>();

        public HomeController()
        {
            list.Add(new Song("qwe", "qwewqe", Genre.Electric, 2004, "fdgdgrgvbth"));
            list.Add(new Song("qwe", "qwewqe", Genre.Electric, 2004, "fdgdgrgvbth"));
            list.Add(new Song("qwe", "qwewqe", Genre.Electric, 2004, "fdgdgrgvbth"));
        }

        public IActionResult Index()
        {
            return View(list);
        }

        //public IActionResult Create()
        //{
        //    //if (!ModelState.IsValid) return View();

        //    //list.Add(new_song);
        //    return View();
        //}

        //[HttpPost]
        public IActionResult Create(Song new_song)
        {
            if (!ModelState.IsValid) return View();

            list.Add(new_song);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
