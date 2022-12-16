using MainApp.Data;
using MainApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MainApp.Controllers
{
    public class PredictCropController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PredictCropController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            UserViewModel userViewModel = new UserViewModel();

                //create SelectListItem
                userViewModel.UserList = _context.Users.
                                           Select(a => new SelectListItem
                                           {
                                               Text = a.Name, // name to show in html dropdown
                                               Value = a.Id.ToString() // value of html dropdown
                                           }).ToList();
            
            //pass Model to view
            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Index(UserViewModel userViewModel)
        {
            
            //create SelectListItem
            userViewModel.UserList = _context.Users.
                                       Select(a => new SelectListItem
                                       {
                                           Text = a.Name, // name to show in html dropdown
                                           Value = a.Id.ToString() // value of html dropdown
                                       }).ToList();

                                       
            //pass Model to view
            return View(userViewModel);
        }
        public IActionResult PredictCrop()
        {
            return View();
        }
        
    }
}
