using GestionImmo.Entities;
using GestionImmo.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionImmo.Controllers
{
    public class BuildingController : Controller
    {
        private readonly DatabaseContext _context;

        public BuildingController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Building
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuildingDb.ToListAsync());
        }

        // GET: Building/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.BuildingDb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // GET: Building/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Building/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsPrincipal,FloorSurface")] Building building)
        {
            if (ModelState.IsValid)
            {
                building.Id = Guid.NewGuid();
                _context.Add(building);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(building);
        }

        // GET: Building/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.BuildingDb.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            return View(building);
        }

        // POST: Building/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,IsPrincipal,FloorSurface")] Building building)
        {
            if (id != building.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(building);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingExists(building.Id))
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
            return View(building);
        }

        // GET: Building/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.BuildingDb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // POST: Building/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var building = await _context.BuildingDb.FindAsync(id);
            if (building != null)
            {
                _context.BuildingDb.Remove(building);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingExists(Guid id)
        {
            return _context.BuildingDb.Any(e => e.Id == id);
        }
    }
}
