using System;

namespace PasswordVerificator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give your email");
            var userEmail = Console.ReadLine();

            Console.WriteLine("Give me your Password");
            var userPassword = Console.ReadLine();


            var newUser = new UserCreation(userEmail, userPassword);
            
            newUser.ValidEmail();

           
            
            
            
        }
    }
}
