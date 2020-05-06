using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ODA.Entity;
using ODA.Server.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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



        public async Task<IActionResult> UpdateImage(int? id)
        {
            if (id == null)
                return NotFound();
            //Get Data
            var record = await InjectedService.GetAsync((int)id);
            if (record == null)
                return NotFound();
            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateImage(int? id, IFormFile file)
        {
            if (id == null)
                return NotFound();
            //Get Data
            var record = await InjectedService.GetAsync((int)id);
            if (record == null)
                return NotFound();

            try
            {
                if (file != null)
                {
                    string webRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
                    //Check Extension
                    string[] SupportedLogoTypes = new[] { ".jpg", ".jpeg", ".png" };
                    string SentExtension = Path.GetExtension(file.FileName);
                    if (SupportedLogoTypes.Contains(SentExtension) == false)
                    {
                        ViewBag.error = "The Logo Uploaded is NOT Supported, Currently Supporting .jpg, .png, .jpeg Formats";
                        return View(record);
                    }

                    //Else if File Is Valid
                    string path = string.Format("{0}{1}", webRoot, "uploads\\categories\\");
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    //Proceed
                    string SaveAsName = Guid.NewGuid().ToString() + SentExtension;
                    using (var stream = new FileStream(path + SaveAsName, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    //On Success Copied
                    record.ImageFile = SaveAsName;
                    await InjectedService.UpdateAsync(record);
                }


            }
            catch (Exception ex)
            {
                ViewBag.error = "Error Occurred While Uploading: " + ex.Message;
            }

            return View(record);
        }

    }
}
