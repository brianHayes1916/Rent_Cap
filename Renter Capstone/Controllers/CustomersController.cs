﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Renter_Capstone.Data;
using Renter_Capstone.Models;

namespace Renter_Capstone.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            if (customer == null)
            {
                return View("Create");
            }
            //else if(customer.Leasing == true){
            //    var interested = _context.InterestedParties.Where(inter => inter.Listing == customer.Listing).ToList();
            //    return View("LeasIndex", interested);
            //}
            var listings = _context.Listings.ToList();
            return View(listings);
        }

        // GET: Customers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Listing listing =  _context.Listings.Where(m => m.ListingId == id).Include(m => m.Address).FirstOrDefault();
            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            //ViewData["ListingId"] = new SelectList(_context.Listings, "ListingId", "ListingId");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name,Bio,Renter,Leasing,IdentityUserId,ListingId")] Customer customer)
        {
            
            customer.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (customer.Leasing == true && customer.ListingId == null)
            {
                _context.Add(customer);
                _context.SaveChanges();
                return View("AddListing");
            }
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            //ViewData["ListingId"] = new SelectList(_context.Listings, "ListingId", "ListingId", customer.ListingId);
            var listings = _context.Listings.ToList();
            return View("Index", listings);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            ViewData["ListingId"] = new SelectList(_context.Listings, "ListingId", "ListingId", customer.ListingId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Name,Bio,Renter,Leasing,IdentityUserId,ListingId")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            ViewData["ListingId"] = new SelectList(_context.Listings, "ListingId", "ListingId", customer.ListingId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Listing listing = _context.Listings.Where(c => c.ListingId == id).Include(c => c.Address).FirstOrDefault();
            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        public IActionResult AddListing()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            //ViewData["ListingId"] = new SelectList(_context.Listings, "ListingId", "ListingId");
            return View();
        }

        [HttpPost, ActionName("AddListing")]
        [ValidateAntiForgeryToken]
        public IActionResult AddListing([Bind("ListingId,Prioirty,Images,Cost,Description,SquareFeet,AddressId")] Listing listing)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(cust => cust.IdentityUserId == userId).FirstOrDefault();
            listing.Prioirty = 0;
            _context.Add(listing);
            _context.SaveChanges();
            customer.ListingId = listing.ListingId;
            _context.SaveChanges();
            if (listing.AddressId == 0 || listing.AddressId == null)
            {
                return View("AddAddress");
            }
            return View();
        }

        public IActionResult AddAddress()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            //ViewData["ListingId"] = new SelectList(_context.Listings, "ListingId", "ListingId");
            return View();
        }

        [HttpPost, ActionName("AddAddress")]
        [ValidateAntiForgeryToken]
        public IActionResult AddAddress([Bind("AddressId,StreetAddress,City,State,Latitute,Longitude")] Address address)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);                      
            _context.Add(address);
            _context.SaveChanges();
            var customer = _context.Customers.Where(cust => cust.IdentityUserId == userId).Include(c => c.Listing).Include(c => c.Listing.Address).FirstOrDefault();            
            customer.Listing.AddressId = address.AddressId;
            _context.SaveChanges();
            DeserializeGeo(customer);
            var listings = _context.Listings.ToList();
            return View("Index", listings);
        }

        public async void DeserializeGeo(Customer customer)
        {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={customer.Listing.Address.StreetAddress},{customer.Listing.Address.City},{customer.Listing.Address.State}&key={ApiKey.GOOGLE_API_KEY}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var geocode = JsonConvert.DeserializeObject<JObject>(jsonResult);
                var results = geocode["results"][0];
                var location = results["geometry"]["location"];
                customer.Listing.Address.Latitute = (double)location["lat"];
                customer.Listing.Address.Longitude = (double)location["lng"];
                _context.Update(customer);
            }
           
        }

    }
}
