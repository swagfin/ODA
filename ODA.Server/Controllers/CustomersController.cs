using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODA.Entity;
using ODA.Server.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODA.Server.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerService InjectedService { get; set; }

        public CustomersController(ICustomerService service)
        {
            InjectedService = service;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await InjectedService.GetAllAsync());
        }

        // GET: Customers/Details/5
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

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PrimaryMobile,PrimaryEmail,Address,PlacedOrders,CancelledOrders,CompletedOrders,TokenKey")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await InjectedService.AddAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
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

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PrimaryMobile,PrimaryEmail,Address,PlacedOrders,CancelledOrders,CompletedOrders,TokenKey")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await InjectedService.UpdateAsync(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (InjectedService.Get(customer.Id) == null)
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
            return View(customer);
        }

        // GET: Customers/Delete/5
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
