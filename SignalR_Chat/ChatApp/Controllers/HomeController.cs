using ChatApp.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }



        public IActionResult Index(string group)
        {
            if (string.IsNullOrEmpty(group))
            {
                group =  "Ümumi";
            }
            ViewBag.Group = group;
            return View(_context.Messages.Where(x=>x.group==group).ToList());
        }

     
    }
}