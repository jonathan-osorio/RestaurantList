using Microsoft.AspNetCore.Mvc;
using RestaurantList.Data;
using RestaurantList.Models;

namespace RestaurantList.Controllers
{
    public class RestaurantList : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
