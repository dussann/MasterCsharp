using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackOverflow.DAO;
using StackOverflow.Data;
using StackOverflow.Models;

namespace StackOverflow.Controllers
{
    public class UsersController : Controller
    {        
        private readonly IUserDAO _userDao;
        public UsersController(IUserDAO userDao)
        {            
            _userDao = userDao;
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(string userValue, string passValue)
        {            
            User user = _userDao.GetUser(userValue, passValue);
            if (user != null)
            {                
                TempData["userName"] = user.UserName;
                TempData["userId"] = user.ID;
                return RedirectToAction("Index", "Questions");
            }
            else
            {
                TempData["ErrorMsg"] = "Wrong user name or password";
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> LogOut()
        {   
           TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
        // GET: Users
         public async Task<IActionResult> Index()
         {
            //return View(await _context.Users.ToListAsync());
            return View(await _userDao.GetAllUsers());
        }

         // GET: Users/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: Users/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]  
         public async Task<IActionResult> Create(User user)
         {
             if (ModelState.IsValid)
             {
                 User checkUser = _userDao.GetUser(user.UserName, user.Password);
                 //User u = _context.Users.FirstOrDefault(x => x.Password == user.Password);
                 if (checkUser == null)
                 {
                    _userDao.CreateUser(user);                     

                     //await _context.SaveChangesAsync();
                    TempData["userName"] = user.UserName;
                    TempData["userId"] = user.ID;
                    return RedirectToAction("Index", "Questions");
                 }
                 else
                 {
                     TempData["ErrorMsg"] = "Password is already used";
                     return View();
                 }
             }
             return View(user);
         }      

         private bool UserExists(int id)
         {
            return false;
             //return _context.Users.Any(e => e.ID == id);
         }
    }
}
