using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class CourseGroupsController : Controller
    {
        private readonly DataContext _context;

        public CourseGroupsController(DataContext context)
        {
            _context = context;
        }

        // GET: CourseGroups
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.CourseGroups.Include(c => c.Course).Include(c => c.Group);
            return View(await dataContext.ToListAsync());
        }

        // GET: CourseGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseGroup = await _context.CourseGroups
                .Include(c => c.Course)
                .Include(c => c.Group)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseGroup == null)
            {
                return NotFound();
            }

            return View(courseGroup);
        }
        [Authorize(Roles = "user,admin")]
        // GET: CourseGroups/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupNumber");
            return View();
        }

        // POST: CourseGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "user,admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,GroupId")] CourseGroup courseGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseGroup.CourseId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", courseGroup.GroupId);
            return View(courseGroup);
        }
        [Authorize(Roles = "user,admin")]
        // GET: CourseGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseGroup = await _context.CourseGroups.FindAsync(id);
            if (courseGroup == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseGroup.CourseId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", courseGroup.GroupId);
            return View(courseGroup);
        }

        // POST: CourseGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "user,admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,GroupId")] CourseGroup courseGroup)
        {
            if (id != courseGroup.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseGroupExists(courseGroup.CourseId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseGroup.CourseId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", courseGroup.GroupId);
            return View(courseGroup);
        }

        // GET: CourseGroups/Delete/5
        [Authorize(Roles = "user,admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseGroup = await _context.CourseGroups
                .Include(c => c.Course)
                .Include(c => c.Group)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseGroup == null)
            {
                return NotFound();
            }

            return View(courseGroup);
        }

        [Authorize(Roles = "user,admin")]
        // POST: CourseGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseGroup = await _context.CourseGroups.FindAsync(id);
            _context.CourseGroups.Remove(courseGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseGroupExists(int id)
        {
            return _context.CourseGroups.Any(e => e.CourseId == id);
        }
    }
}
