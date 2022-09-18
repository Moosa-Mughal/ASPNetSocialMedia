using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetSocialMedia.Data;
using ASPNetSocialMedia.Models;

namespace ASPNetSocialMedia.Controllers
{
    public class FriendshipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FriendshipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Friendships
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Friendship.Include(f => f.Friend).Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Friendships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Friendship == null)
            {
                return NotFound();
            }

            var friendship = await _context.Friendship
                .Include(f => f.Friend)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.RelationId == id);
            if (friendship == null)
            {
                return NotFound();
            }

            return View(friendship);
        }

        // GET: Friendships/Create
        public IActionResult Create()
        {
            ViewData["FriendId"] = new SelectList(_context.User, "Id", "Email");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
            return View();
        }

        // POST: Friendships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelationId,UserId,FriendId")] Friendship friendship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friendship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FriendId"] = new SelectList(_context.User, "Id", "Email", friendship.FriendId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", friendship.UserId);
            return View(friendship);
        }

        // GET: Friendships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Friendship == null)
            {
                return NotFound();
            }

            var friendship = await _context.Friendship.FindAsync(id);
            if (friendship == null)
            {
                return NotFound();
            }
            ViewData["FriendId"] = new SelectList(_context.User, "Id", "Email", friendship.FriendId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", friendship.UserId);
            return View(friendship);
        }

        // POST: Friendships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RelationId,UserId,FriendId")] Friendship friendship)
        {
            if (id != friendship.RelationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendshipExists(friendship.RelationId))
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
            ViewData["FriendId"] = new SelectList(_context.User, "Id", "Email", friendship.FriendId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", friendship.UserId);
            return View(friendship);
        }

        // GET: Friendships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Friendship == null)
            {
                return NotFound();
            }

            var friendship = await _context.Friendship
                .Include(f => f.Friend)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.RelationId == id);
            if (friendship == null)
            {
                return NotFound();
            }

            return View(friendship);
        }

        // POST: Friendships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Friendship == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Friendship'  is null.");
            }
            var friendship = await _context.Friendship.FindAsync(id);
            if (friendship != null)
            {
                _context.Friendship.Remove(friendship);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendshipExists(int id)
        {
          return _context.Friendship.Any(e => e.RelationId == id);
        }
    }
}
