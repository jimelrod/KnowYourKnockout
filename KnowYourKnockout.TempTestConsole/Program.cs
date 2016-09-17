using KnowYourKnockout.Business;
using KnowYourKnockout.Data;
using KnowYourKnockout.Data.Models;
using KnowYourKnockout.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowYourKnockout.TempTestConsole
{
    public class Program
    {
        private const string CONN_STRING = @"Server=DESKTOP-STNOHJO;Database=KnowYourKnockout;Trusted_Connection=True";

        private static UserLogic _userLogic;

        public static void Main(string[] args)
        {
            DbContextOptionsBuilder<KnowYourKnockoutContext> builder = new DbContextOptionsBuilder<KnowYourKnockoutContext>();
            builder.UseSqlServer(CONN_STRING);

            IKnowYourKnockoutContext context = new KnowYourKnockoutContext(builder.Options);
            IKnowYourKnockoutRepository<User, Guid> repo = new UserRepository(context);
            IKnowYourKnockoutDataApi api = new KnowYourKnockoutDataApi(repo);
            _userLogic = new UserLogic(api);

            Go();
            Go();
            Go();
            Go();

            Console.WriteLine("END");
        }

        private static void Go()
        {
            Start();
            GetUsers();
            var id = AddUser();
            var user = GetUser(id);
            var isSuccess = DeleteUser(user);
            Console.WriteLine(isSuccess);
            End();
        }

        private static List<User> GetUsers()
        {
            Console.WriteLine("GetUsers");
            Start();

            var users = _userLogic.GetUsers();

            End();

            return users;
        }

        private static Guid AddUser()
        {
            Console.WriteLine("AddUser");
            Start();

            var user = _userLogic.AddUser(new User { DisplayName = "Jjjjjjj", EmailAddress = "jjjjj@gmail.com" });

            End();

            return user.Id;
        }

        private static User GetUser(Guid id)
        {
            Console.WriteLine("GetUser");
            Start();

            var user = _userLogic.GetUser(id);

            End();

            return user;
        }

        private static bool DeleteUser(User user)
        {
            Console.WriteLine("DeleteUser");
            Start();

            var isSuccess = _userLogic.DeleteUser(user, true);

            End();

            return isSuccess;
        }

        private static void Start()
        {
            Console.WriteLine(string.Format("Start Time: {0}", DateTime.Now.ToString()));
        }

        private static void End()
        {
            Console.WriteLine(string.Format("End Time: {0}", DateTime.Now.ToString()));
            Console.WriteLine();
        }
    }
}
