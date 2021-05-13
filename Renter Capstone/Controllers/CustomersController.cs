using System;
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
        public async Task<IActionResult> IndexAsync()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            if (customer == null)
            {
                //var testListing = await GetEstateListings();
                return View("Create");
            }
            //else if (customer.Leasing == true)
            //{
            //    var interested = _context.InterestedParties.Where(inter => inter.Listing == customer.Listing).ToList();
            //    return View("LeasIndex", interested);
            //}
            List<CustomerListing> listings = _context.CustomerListings.ToList();//.Where(lis => lis.YearPref == customer.Year);
            List<IndexViewModel> viewModels = new List<IndexViewModel>();
            foreach (var listing in listings)
            {
                IndexViewModel viewModel = new IndexViewModel()
                {
                    Listing = listing,
                    RealEstateListingRootObject = new RealEstateListing.Rootobject(),
                    RealEstateListingListing = new RealEstateListing.Listing(),                    
                };
                viewModels.Add(viewModel);
               
            }
            return View(viewModels);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerListing listing =  _context.CustomerListings.Where(m => m.ListingId == id).Include(m => m.Address).FirstOrDefault();
            if (listing == null)
            {
                return NotFound();
            }
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Listing = listing;
            viewModel.RealEstateListingListing = await GetEstateListings(listing.Address);

            return View(viewModel);
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
        public async Task<IActionResult> Create([Bind("UserId,Name,Bio,Renter,Leasing,Year,IdentityUserId,ListingId")] Customer customer)
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
                return RedirectToAction(nameof(IndexAsync));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            //ViewData["ListingId"] = new SelectList(_context.Listings, "ListingId", "ListingId", customer.ListingId);
            var listings = _context.CustomerListings;//.Where(lis => lis.YearPref == customer.Year);
            return View("Index", listings);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.CustomerListings.FindAsync(id);
            if (listing == null)
            {
                return NotFound();
            }
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            //ViewData["ListingId"] = new SelectList(_context.Listings, "ListingId", "ListingId", customer.ListingId);
            return View(listing);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListingId,Prioirty,Description,NumberOfRoomMates,YearPref,AddressId")] CustomerListing listing)
        {
            if (id != listing.ListingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(listing.ListingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexAsync));
            }
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            //ViewData["ListingId"] = new SelectList(_context.Listings, "ListingId", "ListingId", customer.ListingId);
            return View(listing);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerListing listing = _context.CustomerListings.Where(c => c.ListingId == id).Include(c => c.Address).FirstOrDefault();
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
            var listing = await _context.CustomerListings.FindAsync(id);
            _context.CustomerListings.Remove(listing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexAsync));
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
        public IActionResult AddListing([Bind("ListingId,Prioirty,Description,NumberOfRoomMates,YearPref,AddressId")] CustomerListing listing)
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
        public async Task<IActionResult> AddAddress([Bind("AddressId,StreetAddress,City,State,Latitute,Longitude")] Address address)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);                      
            _context.Add(address);
            _context.SaveChanges();
            var customer = _context.Customers.Where(cust => cust.IdentityUserId == userId).Include(c => c.Listing).Include(c => c.Listing.Address).FirstOrDefault();            
            customer.Listing.AddressId = address.AddressId;
            customer.Listing.Address = address;
            _context.SaveChanges();
            Customer customerholder = new Customer();
            customerholder = await DeserializeGeo(customer);
            _context.SaveChanges();
            List <IndexViewModel> viewModels = await GetAllViewModels();
            return View("Index", viewModels);
        }

        public async Task<Customer> DeserializeGeo(Customer customer)
        {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={customer.Listing.Address.StreetAddress},{customer.Listing.Address.City},{customer.Listing.Address.State}&key={ApiKey.GOOGLE_API_KEY}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonResult = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var geocode = JsonConvert.DeserializeObject<JObject>(jsonResult);
                    var results = geocode["results"][0];
                    var location = results["geometry"]["location"];
                    customer.Listing.Address.Latitute = (double)location["lat"];
                    customer.Listing.Address.Longitude = (double)location["lng"];                    
                }

                return (customer);
            }
        }


        //public List<SelectListItem> GetCost()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    var bitems = _context.Listings.Select(x => x.Cost).ToList();
        //    foreach(int cost in bitems)
        //    {
        //        items.Add(cost);
        //    }
        //}
        public async Task<IActionResult> FilterListings()
        {
            List<int> price = new List<int>();            
            List<int> bed = new List<int>();
            List<float> bath = new List<float>();
            List<int> roomMates = new List<int>();
            List<CustomerListing> listings = _context.CustomerListings.ToList();//.Where(lis => lis.YearPref == customer.Year);
            List<IndexViewModel> viewModels = new List<IndexViewModel>();
            foreach (var listing in listings)
            {
                IndexViewModel viewModel = new IndexViewModel()
                {
                    Listing = listing,
                    RealEstateListingRootObject = new RealEstateListing.Rootobject(),
                    RealEstateListingListing = await GetEstateListings(listing.Address)
                    
                };
                price.Add(viewModel.RealEstateListingListing.price);
                bed.Add(viewModel.RealEstateListingListing.bedrooms);
                bath.Add(viewModel.RealEstateListingListing.bathrooms);
                roomMates.Add(viewModel.Listing.NumberOfRoomMates);
                viewModels.Add(viewModel);

            }
            price.Add(0);
            bed.Add(0);
            bath.Add(0);
            roomMates.Add(0);
            ViewBag.Price = new SelectList(price);
            ViewBag.Bed = new SelectList(bed);
            ViewBag.Bath = new SelectList(bath);
            ViewBag.RoomMates = new SelectList(roomMates);
            return View(viewModels);
        }

        //[HttpPost, ActionName("Index")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> filterlistings(int price, int bed, float bath, int roomMates)
        {

            List<IndexViewModel> viewModels = await GetAllViewModels();
            if(price != 0)
            {
                foreach(IndexViewModel viewModel in viewModels)
                {
                    if(viewModel.RealEstateListingListing.price > price)
                    {
                        viewModels.Remove(viewModel);
                    }
                }
            }
            if (bed != 0)
            {
                foreach (IndexViewModel viewModel in viewModels)
                {
                    if (viewModel.RealEstateListingListing.bedrooms > bed)
                    {
                        viewModels.Remove(viewModel);
                    }
                }
            }
            if (bath != 0)
            {
                foreach (IndexViewModel viewModel in viewModels)
                {
                    if (viewModel.RealEstateListingListing.bathrooms > bath)
                    {
                        viewModels.Remove(viewModel);
                    }
                }
            }
            if (roomMates != 0)
            {
                foreach (IndexViewModel viewModel in viewModels)
                {
                    if (viewModel.Listing.NumberOfRoomMates > roomMates)
                    {
                        viewModels.Remove(viewModel);
                    }
                }
            }
            return View(viewModels);
        }

        [HttpPost, ActionName("Interested")]
        [ValidateAntiForgeryToken]
        public IActionResult Interested(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(cust => cust.IdentityUserId == userId).FirstOrDefault();
            InterestedParty interested = new InterestedParty();
            interested.Customer = customer;
            interested.CustomerId = customer.CustomerId;
            interested.ListingId = id;
            CustomerListing listed = _context.CustomerListings.Where(lis => lis.ListingId == id).FirstOrDefault();
            interested.Listing = listed;
            _context.Add(interested);
            _context.SaveChanges();
            //var listings = _context.Listings.Where(lis => lis.YearPref == customer.Year);
            return View("Index");
        }

        public async Task<RealEstateListing.Listing> FindPropRentApi(Address address)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://realty-mole-property-api.p.rapidapi.com/salePrice?address={address.StreetAddress},{address.City},{address.State}"),
                Headers =
                {
                    { "x-rapidapi-key", $"{ApiKey.Rent_API_KEY}" },
                    { "x-rapidapi-host", "realty-mole-property-api.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                RealEstateListing.Listing desiredListing = new RealEstateListing.Listing();
                if (response.IsSuccessStatusCode)
                {
                    var estateListing = JsonConvert.DeserializeObject<JObject>(body);
                    var listingResult = estateListing["listings"][0];

                    //one option
                    //RealEstateListing.Listing listing = JsonConvert.DeserializeObject<RealEstateListing.Listing>(listingResult);

                    //RealEstateListing.Listing desiredListing = new RealEstateListing.Listing();
                    desiredListing.address = (string)listingResult["address"];
                    desiredListing.id = (string)listingResult["id"];
                    desiredListing.formattedAddress = (string)listingResult["formattedAddress"];
                    desiredListing.longitude = (float)listingResult["longitude"];
                    desiredListing.latitude = (float)listingResult["latitude"];
                    desiredListing.city = (string)listingResult["city"];
                    desiredListing.state = (string)listingResult["state"];
                    desiredListing.zipcode = (string)listingResult["zipcode"];
                    desiredListing.publishedDate = (DateTime)listingResult["publishedDate"];
                    desiredListing.distance = (float)listingResult["distance"];
                    desiredListing.daysOld = (float)listingResult["daysOld"];
                    desiredListing.correlation = (float)listingResult["correlation"];
                    desiredListing.county = (string)listingResult["county"];
                    desiredListing.bedrooms = (int)listingResult["bedrooms"];
                    desiredListing.bathrooms = (float)listingResult["bathrooms"];
                    desiredListing.propertyType = (string)listingResult["propertyType"];
                    desiredListing.squareFootage = (int)listingResult["squareFootage"];                    
                    desiredListing.price = (int)listingResult["price"];                    
                }
               return (desiredListing);
            }
        }

        public async Task<RealEstateListing.Listing> GetEstateListings(Address address)
        {
            //Address address = new Address();
            //address.City = "Rockwall";
            //address.State = "TX";
            //address.StreetAddress = "1390 Whitney Lakes Drive";
            RealEstateListing.Listing listings = await FindPropRentApi(address);
            //RealEstateListing.Listing listing = listings[0];
            return (listings);
        }

        public async Task<List<IndexViewModel>> GetAllViewModels()
        {
            List<CustomerListing> listings = _context.CustomerListings.ToList();//.Where(lis => lis.YearPref == customer.Year);
            List<IndexViewModel> viewModels = new List<IndexViewModel>();
            foreach (var listing in listings)
            {
                IndexViewModel viewModel = new IndexViewModel()
                {
                    Listing = listing,
                    RealEstateListingRootObject = new RealEstateListing.Rootobject(),
                    RealEstateListingListing = await GetEstateListings(listing.Address)  
                    //pass in listing.address when you fix GetEstateListings
                };
                viewModels.Add(viewModel);

            }
            return (viewModels);
        }

    }
}
