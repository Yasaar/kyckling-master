using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kyckling.Domain.Infrastructure.Services;

namespace Kyckling.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        //
        // GET: /Reservation/
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List(int id = 0) //Visar alla reservationer för en viss restaurang (inloggad user)
        {
            var model = _reservationService.GetReservations(id);
            return View(model);
        }

    }
}
