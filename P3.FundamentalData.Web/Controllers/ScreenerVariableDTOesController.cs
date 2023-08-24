using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P3.FundamentalData.Web.Data;
using P3.FundamentalData.Web.Models;

namespace P3.FundamentalData.Web.Controllers
{
    public class ScreenerVariableDTOesController : Controller
    {
        private readonly P3FundamentalDataWebContext _context;

        public ScreenerVariableDTOesController(P3FundamentalDataWebContext context)
        {
            _context = context;
        }

        // GET: ScreenerVariableDTOes
        public async Task<IActionResult> Index()
        {
              return _context.ScreenerVariableDTO != null ? 
                          View(await _context.ScreenerVariableDTO.ToListAsync()) :
                          Problem("Entity set 'P3FundamentalDataWebContext.ScreenerVariableDTO'  is null.");
        }

        // GET: ScreenerVariableDTOes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ScreenerVariableDTO == null)
            {
                return NotFound();
            }

            var screenerVariableDTO = await _context.ScreenerVariableDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screenerVariableDTO == null)
            {
                return NotFound();
            }

            return View(screenerVariableDTO);
        }

        // GET: ScreenerVariableDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScreenerVariableDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,varType,varName,Category")] ScreenerVariableDTO screenerVariableDTO)
        {
            if (ModelState.IsValid)
            {
                screenerVariableDTO.Id = Guid.NewGuid();
                _context.Add(screenerVariableDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(screenerVariableDTO);
        }

        // GET: ScreenerVariableDTOes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ScreenerVariableDTO == null)
            {
                return NotFound();
            }

            var screenerVariableDTO = await _context.ScreenerVariableDTO.FindAsync(id);
            if (screenerVariableDTO == null)
            {
                return NotFound();
            }
            return View(screenerVariableDTO);
        }

        // POST: ScreenerVariableDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,varType,varName,Category")] ScreenerVariableDTO screenerVariableDTO)
        {
            if (id != screenerVariableDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screenerVariableDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreenerVariableDTOExists(screenerVariableDTO.Id))
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
            return View(screenerVariableDTO);
        }

        // GET: ScreenerVariableDTOes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ScreenerVariableDTO == null)
            {
                return NotFound();
            }

            var screenerVariableDTO = await _context.ScreenerVariableDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screenerVariableDTO == null)
            {
                return NotFound();
            }

            return View(screenerVariableDTO);
        }

        // POST: ScreenerVariableDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ScreenerVariableDTO == null)
            {
                return Problem("Entity set 'P3FundamentalDataWebContext.ScreenerVariableDTO'  is null.");
            }
            var screenerVariableDTO = await _context.ScreenerVariableDTO.FindAsync(id);
            if (screenerVariableDTO != null)
            {
                _context.ScreenerVariableDTO.Remove(screenerVariableDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreenerVariableDTOExists(Guid id)
        {
          return (_context.ScreenerVariableDTO?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
