using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTask.Controllers
{
    public class GenreController : Controller
    {
        private static SongDBContext _context;

        public GenreController(SongDBContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if (genre.Name == String.Empty || genre.Name == null) return View();

            _context.Genres.Add(genre);
            _context.SaveChanges();

            return View();
        }
    }
}
