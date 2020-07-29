using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IslamByAge.Core.Domain;
using IslamByAge.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;

namespace IslamByAge.Web.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopicsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin,Author,Reader,Editor")]
        // GET: Topics
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Topics.Include(t => t.Category);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "Admin,Author,Reader,Editor")]
        // GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }
        [Authorize(Roles = "Admin,Author,Editor")]
        // GET: Topics/Create
        public IActionResult CreateOrEdit(int? id)
        {
            if (id==null)
            {
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Title");
                return View(new Topic());
            }
            else
            {
                var topic =  _context.Topics.Find(id);
                if (topic == null)
                {
                    return NotFound();
                }
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Title", topic.CategoryId);
                return View(topic);
            }
        }
        [Authorize(Roles = "Admin,Author,Editor")]
        // POST: Topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit([Bind("Title,Description,Body,Status,CategoryId,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,DeletedOn,DeletedBy,Id")] Topic topic)
        {
            if (topic.Id==default)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(topic);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Title", topic.CategoryId);
                return View(topic);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(topic);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TopicExists(topic.Id))
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
                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Title", topic.CategoryId);
                return View(topic);
            }
        }
        [Authorize(Roles = "Admin,Author")]
        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }
        [Authorize(Roles = "Admin,Author")]
        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.Id == id);
        }
    }
}
