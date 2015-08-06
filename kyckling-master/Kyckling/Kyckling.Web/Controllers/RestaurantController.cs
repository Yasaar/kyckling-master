using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kyckling.Domain.Infrastructure.Services;
using Kyckling.Domain.Models;
using Kyckling.Web.Infrastructure.Repositories;
using Kyckling.Web.Models;
using Ninject.Activation;

namespace Kyckling.Web.Controllers
{

    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public ActionResult Index()
        {
            var model = new ListRestaurantsModel();
            var restaurants = _restaurantService.GetAllRestaurants().ToList();
            foreach (var r in restaurants.Where(x => x.Active))
            {
                model.Restaurants.Add(new RestaurantModel
                {
                    Id = r.Id,
                    Active = r.Active,
                    City = r.City,
                    Description = r.Description,
                    Email = r.Email,
                    ImageUrl = r.ImageUrl,
                    MaxGuests = r.MaxGuests,
                    Name = r.Name,
                    PostalCode = r.PostalCode,
                    OpenTimes = r.OpenTimes,
                    StreetAddress = r.StreetAddress
                });
            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var r = _restaurantService.GetRestaurant(id);
            var model = new RestaurantModel
            {
                Active = r.Active,
                City = r.City,
                DayCapacity = r.DayCapacity,
                Description = r.Description,
                Email = r.Email,
                Id = r.Id,
                ImageUrl = r.ImageUrl,
                MaxGuests = r.MaxGuests,
                MaxPersonsBooking = r.MaxPersonsBooking,
                StreetAddress = r.StreetAddress,
                PostalCode = r.PostalCode,
                OpenTimes = r.OpenTimes,
                Name = r.Name
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(string q)
        {
            var searchFor = q;
            var model = new ListRestaurantsModel();
            var restaurants = _restaurantService.GetRestaurantsBySearch(searchFor);
            foreach (var r in restaurants)
            {
                model.Restaurants.Add(new RestaurantModel
                {
                    Id = r.Id,
                    Active = r.Active,
                    City = r.City,
                    Description = r.Description,
                    Email = r.Email,
                    ImageUrl = r.ImageUrl,
                    MaxGuests = r.MaxGuests,
                    Name = r.Name,
                    PostalCode = r.PostalCode,
                    OpenTimes = r.OpenTimes,
                    StreetAddress = r.StreetAddress
                });
            }
            return View(model);
        }

        [Authorize]
        public ActionResult EditRestaurant()
        {
            Restaurant restaurantModel = _restaurantService.GetRestaurant(User.Identity.Name);
            RestaurantModel model = new RestaurantModel()
            {
                Active = restaurantModel.Active,
                City = restaurantModel.City,
                Description = restaurantModel.Description,
                Email = restaurantModel.Email,
                MaxGuests = restaurantModel.MaxGuests,
                ImageUrl = restaurantModel.ImageUrl,
                OpenTimes = new List<OpenTime>(),
                Name = restaurantModel.Name,
                PostalCode = restaurantModel.PostalCode,
                StreetAddress = restaurantModel.StreetAddress,
                Id = restaurantModel.Id,
                DayCapacity = restaurantModel.DayCapacity,
                MaxPersonsBooking = restaurantModel.MaxPersonsBooking
                
            };
            if (restaurantModel.ClosedDates.Count() > 0)
            {
                string s = "";
                foreach (var closedDate in restaurantModel.ClosedDates)
                {
                    s += closedDate.ClosedDate.ToShortDateString() + ",";
                }
                s = s.TrimEnd(',');
                model.ClosedDates = s;
            }
            else model.ClosedDates = "";
            model.OpenTimes = restaurantModel.OpenTimes.ToList();
            return View(model);
        }

        [Authorize, HttpPost]
        public ActionResult EditRestaurant(RestaurantModel model)
        {
            if (ModelState.IsValid)
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Active = model.Active;
                restaurant.Description = model.Description;
                restaurant.Email = model.Email;
                restaurant.Username = User.Identity.Name;
                restaurant.StreetAddress = model.StreetAddress;
                restaurant.City = model.City;
                restaurant.PostalCode = model.PostalCode;
                restaurant.MaxGuests = model.MaxGuests;
                restaurant.OpenTimes = new List<OpenTime>();
                restaurant.OpenTimes = model.OpenTimes.ToList();
                restaurant.Id = model.Id;
                restaurant.MaxPersonsBooking = model.MaxPersonsBooking;
                restaurant.DayCapacity = model.DayCapacity;
                if (model.Image != null)
                {
                    if (model.ImageUrl != null) { System.IO.File.Delete(Server.MapPath(model.ImageUrl));}
                    string fileName = Guid.NewGuid().ToString() +
                                      model.Image.FileName.Substring(model.Image.FileName.LastIndexOf('.'));
                    var path = Path.Combine(Server.MapPath("~/Images/UserImages/"), fileName);
                    model.Image.SaveAs(path);
                    restaurant.ImageUrl = "/Images/UserImages/" + fileName;
                }
                if (model.ClosedDates != null)
                {
                    var dates = model.ClosedDates.Split(',');
                    restaurant.ClosedDates=new List<CloseDate>();
                    foreach (var date in dates)
                    {
                        restaurant.ClosedDates.Add(new CloseDate(){ClosedDate = DateTime.Parse(date)});
                    }
                }
                _restaurantService.UpdateRestaurant(restaurant);
            }
            return View(model);
        }
    }
}
