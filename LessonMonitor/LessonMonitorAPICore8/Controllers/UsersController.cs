using LessonMonitorAPICore8.Models;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitorAPICore8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
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
