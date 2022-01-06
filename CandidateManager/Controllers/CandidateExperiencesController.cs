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
    public class CandidateExperiencesController : Controller
    {
        private readonly CMContext _context;
        public CandidateExperiencesController(CMContext context)
        {
            _context = context;
        }



        // GET: CandidateExperiences
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
                return NotFound();

            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(m => m.IdCandidate == id);
            int teste = candidate.IdCandidate;
            ViewBag.Teste = teste;

            return View(await _context.CandidateExperiences.Where(m => m.IdCandidate == candidate.IdCandidate).ToListAsync());
        }

        // GET: CandidateExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var candidateexperience = await _context.CandidateExperiences
                .FirstOrDefaultAsync(m => m.IdCandidateExperience == id);

            ViewBag.Teste = candidateexperience.IdCandidate;
            return View(candidateexperience);
        }

        // GET: CandidateExperiences/Create
        public IActionResult Create(int? id)
        {
            ViewBag.Teste = id;
            return View();
        }

        // POST: CandidateExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CandidateExperience model)
        {
            if (ModelState.IsValid)
            {

            var candidateexperiences = new CandidateExperience()
            {
                IdCandidate = model.IdCandidate,
                Company = model.Company,
                Job = model.Job,
                Description = model.Description,
                Salary = model.Salary,
                BeginDate = model.BeginDate,
                EndDate = model.EndDate,
                InsertDate = System.DateTime.Now
            };
            _context.Add(candidateexperiences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = model.IdCandidate });
            }
            return View(model);
        }

        // GET: CandidateExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateExperience = await _context.CandidateExperiences.FindAsync(id);
            if (candidateExperience == null)
            {
                return NotFound();
            }
            ViewBag.Teste = candidateExperience.IdCandidate;
            return View(candidateExperience);
        }

        // POST: CandidateExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CandidateExperience model)
        {
            if (id != model.IdCandidateExperience)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var candidateexperiences = new CandidateExperience()
                    {
                        IdCandidateExperience = model.IdCandidateExperience,
                        IdCandidate = model.IdCandidate,
                        Company = model.Company,
                        Job = model.Job,
                        Description = model.Description,
                        Salary = model.Salary,
                        BeginDate = model.BeginDate,
                        EndDate = model.EndDate,
                        ModifyDate = System.DateTime.Now
                    };

                    _context.Entry(candidateexperiences).State = EntityState.Modified;

                    _context.Update(candidateexperiences);

                    _context.Entry(candidateexperiences).Property(p => p.InsertDate).IsModified = false;


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExperienceExists(model.IdCandidateExperience))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = model.IdCandidate });
            }
            return View(model);
        }

        // GET: CandidateExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateExperience = await _context.CandidateExperiences
                .FirstOrDefaultAsync(m => m.IdCandidateExperience == id);
            if (candidateExperience == null)
            {
                return NotFound();
            }

            return View(candidateExperience);
        }

        // POST: CandidateExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidateExperience = await _context.CandidateExperiences.FindAsync(id);
            _context.CandidateExperiences.Remove(candidateExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = candidateExperience.IdCandidate });
        }

        private bool CandidateExperienceExists(int id)
        {
            return _context.CandidateExperiences.Any(e => e.IdCandidateExperience == id);
        }
    }
}
