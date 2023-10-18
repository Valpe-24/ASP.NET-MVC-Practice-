using MongoDB.Driver;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BCrypt.Net;
using System.Dynamic;

namespace SchoolApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly MongoDbContext _context;

        public AuthController()
        {
            _context = new MongoDbContext();
        }



        [HttpGet]
        public ActionResult Login() 
        {
            return View();
        }

        public bool IsValidUser(string username, string password)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            var user = _context.User.Find(filter).SingleOrDefault();

            if (user != null)
            {
                string storedPass = user.Password;
                string storedSalt = user.Salt;
                string combinedPassword = BCrypt.Net.BCrypt.HashPassword(password, storedSalt);

                if (combinedPassword == storedPass)
                {
                    return true;
                }
            }

            return false;
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            
                if (IsValidUser(user.Username, user.Password))
                {
                    //FormsAuthentication.SetAuthCookie(user.Username, false);

                    if (user.Role == Utils.UserRole.teacher)
                    {
                        return RedirectToAction("Index", "Dashboard", new { id = user.Id.ToString() });
                    }

                    if (user.Role == Utils.UserRole.student)
                    {
                        return RedirectToAction("Index", "Dashboard", new { id = user.Id.ToString() });
                    }

                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                    Console.ReadKey();
                    return View(user);
                }

            return View(user);
        }



        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!user.validateName())
            {
                return Content("name");
            }
            else if (!user.validateLastName())
            {
                return Content("lastName");
            }
            else if (!user.validateEmail())
            {
                return Content("email");
            }
            else if(!user.validateUsername())
            {
                return Content("userName");
            }
            else if (!user.validatePassword())
            {
                return Content("password");
            }
            else if (user.validateRole())
            {
                return Content("role");
            }
            else
            {
                string inputPassword = user.Password;
                string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(inputPassword, salt);

                var NewUser = new User()
                {
                    Name = user.Name,
                    Lastname = user.Lastname,
                    Username = user.Username,
                    Password = hashedPassword,
                    Salt = salt,
                    Email = user.Email,
                    Role = user.Role,

                };
                _context.User.InsertOne(NewUser);
                return Content("0");
            }
        }


    }

}