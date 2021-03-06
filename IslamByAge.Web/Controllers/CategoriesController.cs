﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IslamByAge.Core.Domain;
using IslamByAge.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using IslamByAge.Core.Constants;
using Microsoft.AspNetCore.Identity;

namespace IslamByAge.Web.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoriesController(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }
        [Authorize(Roles="Admin,Author,Reader,Editor")]
        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var categories = _context.Categories.AsQueryable();
            if (User.IsInRole("Author"))
            {
                categories = categories.Where(e => e.CreatedBy == userId);
            }
            return View(await categories.ToListAsync());
        }
        [Authorize(Roles = "Admin,Author,Reader,Editor")]
        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [Authorize(Roles = "Admin,Author,Editor")]
        // GET: Categories/Create
        public IActionResult CreateOrEdit(int? id)
        {
            if (id==null)
            {
                return View(new Category());
            }
            else
            {
                var category =  _context.Categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }
        }
        [Authorize(Roles = "Admin,Author,Editor")]
        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit([Bind("Title,Image,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,DeletedOn,DeletedBy,Id")] Category category)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if (category.Id==default)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(category);
                    category.CreatedBy = userId;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        category.UpdatedBy = userId;
                        _context.Update(category);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(category.Id))
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
                return View(category);
            }
        }

        [Authorize(Roles = "Admin,Author")]
        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [Authorize(Roles = "Admin,Author")]
        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
