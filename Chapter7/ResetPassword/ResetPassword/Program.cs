using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace ResetPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Artist", "ArtistId", "UserName", autoCreateTables: true);
                Console.WriteLine("Web Security has been initialized");
                Console.WriteLine("Enter your user name");
                var username = Console.ReadLine();
                string token = WebSecurity.GeneratePasswordResetToken(username);
                Console.WriteLine("Your password tocken is {0}", token);
                Console.WriteLine("Enter your new password");
                var newpassword = Console.ReadLine();
                WebSecurity.ResetPassword(token, newpassword);
                Console.WriteLine("Your Password has been reset");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Web Security  initialized has failed");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }
    }
}
