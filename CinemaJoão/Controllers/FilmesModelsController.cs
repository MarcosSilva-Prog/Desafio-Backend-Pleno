using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaJoão.Data;
using CinemaJoão.Models;
using Microsoft.AspNetCore.Authorization;

namespace CinemaJoão.Controllers
{
    [Authorize] 
    public class FilmesModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FilmesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmes.ToListAsync());
        }

        // GET: FilmesModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmesModel = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmesModel == null)
            {
                return NotFound();
            }

            return View(filmesModel);
        }

        // GET: FilmesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Filme,Genero,Ano,LinkImg")] FilmesModel filmesModel)
        {
            if (ModelState.IsValid)
            {
                filmesModel.Id = Guid.NewGuid();
                _context.Add(filmesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmesModel);
        }

        // GET: FilmesModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmesModel = await _context.Filmes.FindAsync(id);
            if (filmesModel == null)
            {
                return NotFound();
            }
            return View(filmesModel);
        }

        // POST: FilmesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Filme,Genero,Ano,LinkImg")] FilmesModel filmesModel)
        {
            if (id != filmesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmesModelExists(filmesModel.Id))
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
            return View(filmesModel);
        }

        // GET: FilmesModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmesModel = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmesModel == null)
            {
                return NotFound();
            }

            return View(filmesModel);
        }

        // POST: FilmesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var filmesModel = await _context.Filmes.FindAsync(id);
            _context.Filmes.Remove(filmesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmesModelExists(Guid id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
