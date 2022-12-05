using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class Booking_InfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Booking_InfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking_Info
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Booking_Info.Include(b => b.hotel_Customer).Include(b => b.hotel_Room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Booking_Info/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking_Info = await _context.Booking_Info
                .Include(b => b.hotel_Customer)
                .Include(b => b.hotel_Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking_Info == null)
            {
                return NotFound();
            }

            return View(booking_Info);
        }

        // GET: Booking_Info/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name");
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Room_No");
            return View();
        }

        // POST: Booking_Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,RoomId")] Booking_Info booking_Info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking_Info);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", booking_Info.CustomerId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Room_No", booking_Info.RoomId);
            return View(booking_Info);
        }

        // GET: Booking_Info/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking_Info = await _context.Booking_Info.FindAsync(id);
            if (booking_Info == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", booking_Info.CustomerId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Room_No", booking_Info.RoomId);
            return View(booking_Info);
        }

        // POST: Booking_Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,RoomId")] Booking_Info booking_Info)
        {
            if (id != booking_Info.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking_Info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Booking_InfoExists(booking_Info.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", booking_Info.CustomerId);
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Room_No", booking_Info.RoomId);
            return View(booking_Info);
        }

        // GET: Booking_Info/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking_Info = await _context.Booking_Info
                .Include(b => b.hotel_Customer)
                .Include(b => b.hotel_Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking_Info == null)
            {
                return NotFound();
            }

            return View(booking_Info);
        }

        // POST: Booking_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking_Info = await _context.Booking_Info.FindAsync(id);
            _context.Booking_Info.Remove(booking_Info);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Booking_InfoExists(int id)
        {
            return _context.Booking_Info.Any(e => e.Id == id);
        }
    }
}
