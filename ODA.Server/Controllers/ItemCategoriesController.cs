using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ODA.Entity;
using ODA.Server.Data;
using ODA.Server.Services;

namespace ODA.Server.Controllers
{
    public class ItemCategoriesController : Controller
    {
        private IItemCategoryService InjectedService { get; set; }

        public ItemCategoriesController(IItemCategoryService context)
        {
            InjectedService = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await InjectedService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            //Get Data
            var record = await InjectedService.GetAsync((int)id);
            if (record == null)
                return NotFound();
            return View(record);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageFile,MinimumPrice,WaitTimeInMin")] ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                await InjectedService.AddAsync(itemCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(itemCategory);
        }

        // GET: ItemCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            //Get Data
            var record = await InjectedService.GetAsync((int)id);
            if (record == null)
                return NotFound();
            return View(record);
        }

        // POST: ItemCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageFile,MinimumPrice,WaitTimeInMin")] ItemCategory itemCategory)
        {
            if (id != itemCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await InjectedService.UpdateAsync(itemCategory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (InjectedService.Get(itemCategory.Id) == null)
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
            return View(itemCategory);
        }

        // GET: ItemCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            //Get Data
            var record = await InjectedService.GetAsync((int)id);
            if (record == null)
                return NotFound();
            return View(record);
        }

        // POST: ItemCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Get Data
            var record = await InjectedService.GetAsync((int)id);
            if (record == null)
                return NotFound();
            InjectedService.Remove(record);
            return RedirectToAction(nameof(Index));
        }


    }
}
