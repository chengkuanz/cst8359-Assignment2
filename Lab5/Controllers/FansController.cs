using Lab5.Data;
using Lab5.Models;
using Lab5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Controllers
{
    public class FansController : Controller
    {
        private readonly SportsDbContext _context;

        public FansController(SportsDbContext context)
        {
            _context = context;
        }


        //assg2: iii.	Edit the list of subscriptions for each Fan, which happens in Fans/EditSubscriptions
        // GET: Fans/EditSubscriptions/1
        public async Task<IActionResult> EditSubscriptions(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Find Fan
            var fan = await _context.Fans
                .Include(f => f.Subscriptions)
                .ThenInclude(s => s.SportClub)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (fan == null)
            {
                return NotFound();
            }

            var allClubs = await _context.SportClubs.ToListAsync();
            var viewModel = new SubscriptionViewModel
            {
                Fan = fan,
                Subscriptions = fan.Subscriptions.Select(s => new SubscriptionViewModel
                {
                    SportClubName = s.SportClub.Title,
                    SportClubId = s.SportClubId
                }).ToList(),
                AllClubs = allClubs
            };

            return View(viewModel);
        }

        // POST: Fans/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubscription(int fanId, string clubId)
        {
            var subscription = new Subscription
            {
                FanId = fanId,
                SportClubId = clubId
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EditSubscriptions), new { id = fanId });
        }

        // POST: Fans/Unregister
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveSubscription(int fanId, string clubId)
        {
            //Find Subscription
            var subscription = await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.FanId == fanId && s.SportClubId == clubId);

            //Remove Subscription
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }

            //Redirect to EditSubscriptions
            return RedirectToAction(nameof(EditSubscriptions), new { id = fanId });
        }


        //assignment2: display subscription on the fan- index page 
        // GET: Fans
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Fans.ToListAsync());
        //}
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new FanViewModel
            {
                Fans = await _context.Fans
                    .Include(f => f.Subscriptions)
                    .ThenInclude(s => s.SportClub)
                    .AsNoTracking()
                    .OrderBy(f => f.LastName)
                    .ToListAsync()
            };

            if (id != null)
            {
                ViewData["FanID"] = id.Value;
                viewModel.Subscriptions = viewModel.Fans.Where(
                    f => f.Id == id.Value).Single().Subscriptions;
                viewModel.SportClubs = viewModel.Subscriptions.Select(s => s.SportClub);
            }

            return View(viewModel);
        }

        // GET: Fans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fan = await _context.Fans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fan == null)
            {
                return NotFound();
            }

            return View(fan);
        }

        // GET: Fans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,BirthDate")] Fan fan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fan);
        }

        // GET: Fans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fan = await _context.Fans.FindAsync(id);
            if (fan == null)
            {
                return NotFound();
            }
            return View(fan);
        }

        // POST: Fans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,BirthDate")] Fan fan)
        {
            if (id != fan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FanExists(fan.Id))
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
            return View(fan);
        }

        // GET: Fans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fan = await _context.Fans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fan == null)
            {
                return NotFound();
            }

            return View(fan);
        }

        // POST: Fans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fan = await _context.Fans.FindAsync(id);
            if (fan != null)
            {
                _context.Fans.Remove(fan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FanExists(int id)
        {
            return _context.Fans.Any(e => e.Id == id);
        }
    }
}
