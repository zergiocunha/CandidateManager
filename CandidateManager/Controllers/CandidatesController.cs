#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidateManager.Models.Context;
using GestorDeCandidatos.Models;

namespace CandidateManager.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly CMContext _context;

        public CandidatesController(CMContext context)
        {
            _context = context;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidates.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(m => m.IdCandidate == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidate model)
        {
            try
            {

                var bd = _context;
                var existeEmail = await bd.Candidates
                    .FirstOrDefaultAsync(m => m.IdCandidate == model.IdCandidate);

                if (ModelState.IsValid)
                {

               

                    var candidate = new Candidate()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Birthdate = model.Birthdate,
                        Email = model.Email,
                        InsertDate = System.DateTime.Now
                    };

                    _context.Add(candidate);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
              

                }
                return View(model);
            }
            catch (Exception ex)
            {
            }
            return View();
        }


        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IdCandidate,Name,Surname,Birthdate,Email,InsertDate,ModifyDate")] Candidate candidate)
        public async Task<IActionResult> Edit(int id, Candidate model)
        {
            if (id != model.IdCandidate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {


                    var candidate = new Candidate()
                    {
                        IdCandidate = id,
                        Name = model.Name,
                        Surname = model.Surname,
                        Birthdate = model.Birthdate,
                        Email = model.Email,
                        ModifyDate = System.DateTime.Now
                    };
                    _context.Entry(candidate).State = EntityState.Modified;

                    _context.Update(candidate);

                    _context.Entry(candidate).Property(p => p.InsertDate).IsModified = false;


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(model.IdCandidate))
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
            return View(model);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(m => m.IdCandidate == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.IdCandidate == id);
        }

    }
}
