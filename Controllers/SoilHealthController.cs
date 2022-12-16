using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MainApp.Data;
using MainApp.Models;

namespace MainApp.Controllers
{
    public class SoilHealthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SoilHealthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SoilHealth
        public async Task<IActionResult> Index()
        {
              return View(await _context.SoilInfo.ToListAsync());
        }


        // GET: SoilHealth/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SoilInfo == null)
            {
                return NotFound();
            }

            var soilHealthParameters = await _context.SoilInfo
                .FirstOrDefaultAsync(m => m.SoilId == id);
            if (soilHealthParameters == null)
            {
                return NotFound();
            }

            return View(soilHealthParameters);
        }

        // GET: SoilHealth/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SoilHealth/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoilId,SoilName,pH,EC,OC,OM,N,P,K,Zn,Fe,Cu,Mn,CaCO3,SoilNature")] SoilHealthParameters soilHealthParameters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soilHealthParameters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soilHealthParameters);
        }

        // GET: SoilHealth/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SoilInfo == null)
            {
                return NotFound();
            }

            var soilHealthParameters = await _context.SoilInfo.FindAsync(id);
            if (soilHealthParameters == null)
            {
                return NotFound();
            }
            return View(soilHealthParameters);
        }

        // POST: SoilHealth/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoilId,SoilName,pH,EC,OC,OM,N,P,K,Zn,Fe,Cu,Mn,CaCO3,SoilNature")] SoilHealthParameters soilHealthParameters)
        {
            if (id != soilHealthParameters.SoilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soilHealthParameters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoilHealthParametersExists(soilHealthParameters.SoilId))
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
            return View(soilHealthParameters);
        }

        // GET: SoilHealth/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SoilInfo == null)
            {
                return NotFound();
            }

            var soilHealthParameters = await _context.SoilInfo
                .FirstOrDefaultAsync(m => m.SoilId == id);
            if (soilHealthParameters == null)
            {
                return NotFound();
            }

            return View(soilHealthParameters);
        }

        // POST: SoilHealth/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SoilInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SoilInfo'  is null.");
            }
            var soilHealthParameters = await _context.SoilInfo.FindAsync(id);
            if (soilHealthParameters != null)
            {
                _context.SoilInfo.Remove(soilHealthParameters);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoilHealthParametersExists(int id)
        {
          return _context.SoilInfo.Any(e => e.SoilId == id);
        }

        // GET: SoilHealth/Details/5
        public PartialViewResult GetSoilInfo(string userid)
        {

            //UserProfile user = (UserProfile)_context.Users.FirstOrDefault(m => m.Id == Convert.ToInt32(userid));

            List<SoilHealthParameters> soilHealthParameters = _context.SoilInfo
                .Where(m => m.UserId == Convert.ToInt32(userid)).ToList();

            return PartialView("_SoilDataTablePartial", soilHealthParameters);
          //  return PartialView(soilHealthParameters);
        }
        public PartialViewResult GetCropsList(int ph)
        {

            //UserProfile user = (UserProfile)_context.Users.FirstOrDefault(m => m.Id == Convert.ToInt32(userid));

            List<Crop> crops = _context.Crops
                .Where(m => m.ReqSoilPh >= ph).ToList();

            return PartialView("_CropsPartial", crops);
            //  return PartialView(soilHealthParameters);
        }

    }
}
