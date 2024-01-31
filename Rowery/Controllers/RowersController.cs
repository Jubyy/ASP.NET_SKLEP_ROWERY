using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Rowery.Models;
using Rowery.Data;
using Rowery.Models;



namespace WypozyczalniaRowerow.Controllers
{
    public class RowersController : Controller
    {

        private readonly RoweryContext _context;

        public RowersController(RoweryContext context)
        {
            _context = context;
        }


        // GET: /HelloWorld/
        public IActionResult Glowna()
        {

            return View();
        }
        // 
        // GET: /HelloWorld/Welcome/ 
        public async Task<IActionResult> Oferta()
        {
            return View(await _context.Rower.ToListAsync());
        }
        public IActionResult Kontakt()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            ViewData["Message"] = "Hello";
            ViewData["NumTimes"] = 10;
            return View();
        }

        // GET: Rowers
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rower.ToListAsync());
        }

        // GET: Rowers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rower = await _context.Rower
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rower == null)
            {
                return NotFound();
            }

            return View(rower);
        }

        // GET: Rowers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rowers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,IsAvailable,url_img,brand,Weight,ReleaseDate")] Rower rower)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rower);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rower);
        }

        // GET: Rowers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rower = await _context.Rower.FindAsync(id);
            if (rower == null)
            {
                return NotFound();
            }
            return View(rower);
        }



        [HttpPost]
        public IActionResult ToggleAvailability(int id, int selectedOption, string rentDate)
        {
            var rower = _context.Rower.Find(id);

            if (rower != null)
            {
                int daysToAdd = selectedOption;

                // Ustaw datę wypożyczenia
                rower.RentDate = DateTime.Now;
                // Dodaj ilość dni do daty zwrotu
                rower.ReturnDate = rower.RentDate.AddDays(daysToAdd);

                // Zmień dostępność
                rower.IsAvailable = !rower.IsAvailable;

                // Zapisz zmiany w bazie danych
                _context.SaveChanges();
            }

            // Przekieruj na potwierdzenie
            return RedirectToAction("Oferta");
        }


        // POST: Rowers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,IsAvailable,url_img,brand,Weight,ReleaseDate,RentDate,ReturnDate")] Rower rower)
        {
            if (id != rower.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RowerExists(rower.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rower);
        }

        // GET: Rowers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rower = await _context.Rower
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rower == null)
            {
                return NotFound();
            }

            return View(rower);
        }

        // POST: Rowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rower = await _context.Rower.FindAsync(id);
            if (rower != null)
            {
                _context.Rower.Remove(rower);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RowerExists(int id)
        {
            return _context.Rower.Any(e => e.Id == id);
        }
    }
}
