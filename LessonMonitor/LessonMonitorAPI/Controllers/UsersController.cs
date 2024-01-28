using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LessonMonitorAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {
            
        }

        [HttpGet]
        public User[] Get(string userName)
        {
            var rnd = new Random();

            var users = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                var user = new User();

                user.Name = userName + i;
                user.Age = rnd.Next(7, 70);

                users.Add(user);
            }
            return users.ToArray();
        }
    }
}
