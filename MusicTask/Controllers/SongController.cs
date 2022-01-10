using MusicTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicTask.Controllers
{
    public class SongController : Controller
    {
        private static SongDBContext _context;

        public SongController(SongDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Songs.Include(nameof(Song.Genre)));
        }

        // GET
        public IActionResult Upset(int? id)
        {
            SongVM viewModel = new SongVM()
            {
                Song = new Song(),
                Genres = _context.Genres.Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null)
            {
                return View(viewModel);
            }
            else
            {
                viewModel.Song = _context.Songs.Find(id);
                if (viewModel.Song == null) return NotFound();

                return View(viewModel);
            }
        }

        // POST
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Upset(SongVM model)
        {
            if (!ModelState.IsValid) return NotFound();

            if (model.Song.Id == 0)
            {
                _context.Songs.Add(model.Song);
                _context.SaveChanges();
            }
            else
            {
                _context.Songs.Update(model.Song);
                _context.SaveChanges();
            }


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0) return NotFound();

            var remove = _context.Songs.Find(id);

            if (remove == null) return NotFound();

            _context.Songs.Remove(remove);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
