using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SchoolApp.Models;

namespace SchoolApp.Controllers
{
    public class DashboardController : Controller
    {
        private UserService _userService;

        public DashboardController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index(string userId)
        {
            var userRole = _userService.GetUserRole(userId);

            if (userRole == Utils.UserRole.teacher)
            {
                return View("TeacherDashboard");
            }
            else 
            {
                return View("StudentDashboard");
            }
            
        }
    }

    public class UserService
    {
        private IMongoCollection<User> _user;

        public UserService(MongoDatabaseBase database)
        {
            _user = database.GetCollection<User>("user");
        }

        public Utils.UserRole GetUserRole(string userId)
        {
            var user = _user.Find(u => u.Id == ObjectId.Parse(userId)).FirstOrDefault();

            return user.Role;

        }
    }
}