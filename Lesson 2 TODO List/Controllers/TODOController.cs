using Lesson_2_TODO_List.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_2_TODO_List.Controllers
{
    public class TODOController : Controller
    {
        public static TODODBContext _context;

        public TODOController(TODODBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.TODOs);
        }

        public IActionResult Returned(string id)
        {
            if (id == null || id == String.Empty) return NotFound();

            _context.TODOs.First(c => c.Id == id).Status = Status.RETURNED;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Complete(string id)
        {
            if (id == null || id == String.Empty) return NotFound();

            _context.TODOs.First(c => c.Id == id).Status = Status.FINISHED;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Working(string id)
        {
            if (id == null || id == String.Empty) return NotFound();

            _context.TODOs.First(c => c.Id == id).Status = Status.WORKING;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Upset()
        {
            /*Checking*/

            TODOVM viewModel = new TODOVM()
            {
                Types = _context.Types.Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(TODO new_todo)
        {
            if (!ModelState.IsValid) return View();

            _context.TODOs.Add(new_todo);
            _context.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
