﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdoptNet.Data;
using anypet.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdoptNet.Controllers
{
    public class AnimalImagesController : Controller
    {
        private readonly AdoptNetContext _context;
        public AnimalImagesController(AdoptNetContext context)
        {
            _context = context;
        }
        // GET: AnimalImages


        // GET: AnimalImages/Create
        [Authorize(Roles = "Admin,Association")]
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", nameof(Animal.Name));
            return View();
        }
        // POST: AnimalImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,AnimalId")] AnimalImage animalImage)
        {
            if (ModelState.IsValid)
            {
                var check = _context.AnimalImage.Where(r => r.AnimalId.Equals(animalImage.AnimalId));
                if (check.Count() == 0)
                {
                    _context.Add(animalImage);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), "Animals");
                }
                else
                {
                    ViewData["Error"] = "this Animal allready  have an image ";

                }
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", nameof(Animal.Name), animalImage.AnimalId);
            return View(animalImage);
        }

        // GET: AnimalImages/Edit/5
        [Authorize(Roles = "Admin,Association")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var animalImage = await _context.AnimalImage.FindAsync(id);
            if (animalImage == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", nameof(Animal.Name), animalImage.AnimalId);
            return View(animalImage);
        }
        // POST: AnimalImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,AnimalId")] AnimalImage animalImage)
        {
            if (id != animalImage.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalImageExists(animalImage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Animals");
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", nameof(Animal.Name), animalImage.AnimalId);
            return View(animalImage);
        }

        // GET: AnimalImages/Delete/5
        [Authorize(Roles = "Admin,Association")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var animalImage = await _context.AnimalImage
                .Include(a => a.Animal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalImage == null)
            {
                return NotFound();
            }
            return View(animalImage);
        }
        // POST: AnimalImages/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalImage = await _context.AnimalImage.FindAsync(id);
            _context.AnimalImage.Remove(animalImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Animals");
        }
        private bool AnimalImageExists(int id)
        {
            return _context.AnimalImage.Any(e => e.Id == id);
        }
    }
}